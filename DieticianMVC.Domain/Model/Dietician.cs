using Microsoft.AspNetCore.Identity;

namespace DieticianMVC.Domain.Model
{
    public class Dietician
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string NIP { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
