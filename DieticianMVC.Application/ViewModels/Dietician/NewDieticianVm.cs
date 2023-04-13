using AutoMapper;
using DieticianMVC.Application.Mapping;
using DieticianMVC.Domain.Model;

namespace DieticianMVC.Application.ViewModels.Dietician
{
    public class NewDieticianVm : IMapFrom<DieticianMVC.Domain.Model.Dietician>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string NIP { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public virtual List<Address> Addresses { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewDieticianVm, DieticianMVC.Domain.Model.Dietician>().ReverseMap();
        }
    }
}
