using AutoMapper;
using DieticianMVC.Application.Mapping;

namespace DieticianMVC.Application.ViewModels.Dietician
{
    public class DieticianForListVm : IMapFrom<DieticianMVC.Domain.Model.Dietician>
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DieticianMVC.Domain.Model.Dietician, DieticianForListVm>()
                .ForMember(s => s.FullName, opt => opt.MapFrom(d => d.FirstName + " " + d.LastName));
        }
    }
}
