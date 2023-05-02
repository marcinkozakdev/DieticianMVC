using AutoMapper;
using DieticianMVC.Application.Mapping;
using Microsoft.AspNetCore.Identity;

namespace DieticianMVC.Application.ViewModels.User
{
    public class UserForListVm : IMapFrom<IdentityUser>
    {
        public string Id { get; set; }
        public string UserName { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<IdentityUser, UserForListVm>();
        }

    }
}
