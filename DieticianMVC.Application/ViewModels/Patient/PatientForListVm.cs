using AutoMapper;
using DieticianMVC.Application.Mapping;

namespace DieticianMVC.Application.ViewModels.Patient
{
    public class PatientForListVm : IMapFrom<DieticianMVC.Domain.Model.Patient>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        //public PatientStatusVm PatientStatus { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DieticianMVC.Domain.Model.Patient, PatientForListVm>()
                .ForMember(d => d.FullName, opt => opt.MapFrom(s => s.FirstName + " " + s.LastName));
        }
    }
}
