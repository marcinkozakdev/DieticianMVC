using AutoMapper;
using DieticianMVC.Application.Mapping;
using Microsoft.AspNetCore.Identity;

namespace DieticianMVC.Application.ViewModels.User
{
    public class UserDetailVm : IMapFrom<IdentityUser>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public List<string> UserRoles { get; set; }
        public List<RoleVm> Roles { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<IdentityUser, UserDetailVm>();
        }
    }
}
