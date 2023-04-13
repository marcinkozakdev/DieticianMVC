using AutoMapper;
using DieticianMVC.Application.Mapping;
using Microsoft.AspNetCore.Identity;

namespace DieticianMVC.Application.ViewModels.User
{
    public class RoleVm : IMapFrom<IdentityRole>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<IdentityRole, RoleVm>();
        }
    }
}
