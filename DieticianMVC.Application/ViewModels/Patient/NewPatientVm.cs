using AutoMapper;
using DieticianMVC.Application.Mapping;
using DieticianMVC.Domain.Model;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DieticianMVC.Application.ViewModels.Patient
{
    public class NewPatientVm : IMapFrom<DieticianMVC.Domain.Model.Patient>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DieticianId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewPatientVm, DieticianMVC.Domain.Model.Patient>().ReverseMap();
        }
    }

    public class NewPatientValidation: AbstractValidator<NewPatientVm>
    {
        public NewPatientValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.FirstName).MaximumLength(25);
            RuleFor(x => x.LastName).MaximumLength(25);
            RuleFor(x => x.EmailAddress).EmailAddress();
            RuleFor(x => x.PhoneNumber).Length(9);
        }
    }
}
