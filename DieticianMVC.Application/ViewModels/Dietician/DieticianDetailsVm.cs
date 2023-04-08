using AutoMapper;
using DieticianMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieticianMVC.Application.ViewModels.Dietician
{
    public class DieticianDetailsVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string NIP { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewDieticianVm, DieticianMVC.Domain.Model.Dietician>().ReverseMap();
        }
    }
}
