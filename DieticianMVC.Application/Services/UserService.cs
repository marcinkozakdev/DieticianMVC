﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using DieticianMVC.Application.Interfaces;
using DieticianMVC.Application.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieticianMVC.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public void RemoveRoleFromUser(string id, string role)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            if (user == null)
            {
                return;
            }
            _userManager.RemoveFromRoleAsync(user, role);
        }

        public async Task<IdentityResult> ChangeUserRolesAsync(string idUser, IEnumerable<string> role)
        {
            var user = await _userManager.FindByIdAsync(idUser);
            if (user == null)
            {
                return null;
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            if (role.ToList().Count > userRoles.Count)
            {
                return await AddRolesToUserAsync(user, role);
            }
            else
            {
                return await RemoveRolesFromUserAsync(user, role);
            }
        }

        public IQueryable<string> GetRolesByUser(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            var roles = _userManager.GetRolesAsync(user).Result.AsQueryable();
            return roles;
        }

        public IQueryable<RoleVm> GetAllRoles()
        {
            var rolesVm = _roleManager.Roles?.ProjectTo<RoleVm>(_mapper.ConfigurationProvider);
            return rolesVm;
        }

        public ListUsersForListVm GetAllUsers(int pageSize, int pageNo, string searchString)
        {
            var users = _userManager.Users
                .Where(p=>p.UserName.Contains(searchString)).ProjectTo<UserForListVm>(_mapper.ConfigurationProvider).ToList();

            var usersToShow = users.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

            var usersVm = new ListUsersForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Users = usersToShow,
                Count = users.Count
            };
            return usersVm;
        }

        public UserDetailVm GetUserDetails(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            var userVm = _mapper.Map<UserDetailVm>(user);
            userVm.UserRoles = GetRolesByUser(user.Id).ToList();
            userVm.Roles = GetAllRoles().ToList();
            return userVm;
        }

        public async Task<IdentityResult> DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return await Task.FromResult<IdentityResult>(null);
            }
            return await _userManager.DeleteAsync(user);
        }

        private async Task<IdentityResult> RemoveRolesFromUserAsync(IdentityUser user, IEnumerable<string> roles)
        {
            var actuallUserRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, actuallUserRoles);
            return await AddRolesToUserAsync(user, roles);

        }

        private async Task<IdentityResult> AddRolesToUserAsync(IdentityUser user, IEnumerable<string> roles)
        {
            IdentityResult result;
            roles = RemoveDuplicateRoles(user, roles);
            result = await _userManager.AddToRolesAsync(user, roles);
            return result;
        }

        private List<string> RemoveDuplicateRoles(IdentityUser user, IEnumerable<string> roles)
        {
            var userRoles = _userManager.GetRolesAsync(user).Result.ToList();
            var rolesToAdd = roles.Where(r => !userRoles.Contains(r)).ToList();
            return rolesToAdd;
        }
    }
}
