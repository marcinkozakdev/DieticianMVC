using AutoMapper;
using DieticianMVC.Application.Mapping;
using DieticianMVC.Domain.Model;

namespace DieticianMVC.Application.ViewModels.Patient
{
    public class LikedProductForListVm : IMapFrom<LikedProduct>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LikedProduct, LikedProductForListVm>();
        }
    }
}
