using DieticianMVC.Domain.Model;

namespace DieticianMVC.Application.ViewModels.Patient
{
    public class PatientForListVm
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public PatientStatusVm PatientStatus { get; set; }
    }
}
