using AutoMapper;
using DieticianMVC.Application.Mapping;
using DieticianMVC.Domain.Model;

namespace DieticianMVC.Application.ViewModels.Dietician
{
    public class AddressForListVm : IMapFrom<Address>
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public int FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, AddressForListVm>().ReverseMap();
        }
    }
}
