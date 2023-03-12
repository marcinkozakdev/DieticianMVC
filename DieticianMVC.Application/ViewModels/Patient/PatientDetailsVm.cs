using AutoMapper;
using DieticianMVC.Application.Mapping;
using DieticianMVC.Domain.Model;

namespace DieticianMVC.Application.ViewModels.Patient
{
    public class PatientDetailsVm : IMapFrom<DieticianMVC.Domain.Model.Patient>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<FoodAllergiesAndIntolerancesForListVm> FoodAllergiesAndIntolerances { get; set; }
        public List<DislikedProductForListVm> DislikedProducts { get; set; }
        public List<LikedProductForListVm> LikedProducts { get; set; }
        public List<NewBodyMeasurementsVm> BodyMeasurements { get; set; }
        public List<Menu> Menus { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PatientDetailsVm, DieticianMVC.Domain.Model.Patient>().ReverseMap();
        }
    }
}
