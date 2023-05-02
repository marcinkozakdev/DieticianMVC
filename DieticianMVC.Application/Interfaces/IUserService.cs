using DieticianMVC.Application.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieticianMVC.Application.Interfaces
{
    public interface IUserService
    {
        ListUsersForListVm GetAllUsers(int pageSize, int pageNo, string searchString);
        IQueryable<RoleVm> GetAllRoles();
        IQueryable<string> GetRolesByUser(string id);
        UserDetailVm GetUserDetails(string id);
        Task<IdentityResult> ChangeUserRolesAsync(string idUser, IEnumerable<string> role);
        void RemoveRoleFromUser(string id, string role);
        Task<IdentityResult> DeleteUserAsync(string id);
    }
}
