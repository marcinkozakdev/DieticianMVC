using DieticianMVC.Domain.Model;
namespace DieticianMVC.Domain.Interfaces
{
    public interface IPatientStatusRepository
    {
        public void DeletePatientStatus(int patientId);
        public PatientStatus AddPatientStatus(PatientStatus patientStatus);
        public PatientStatus UpdatePatientStatus(PatientStatus patientStatus);
        public PatientStatus GetPatientStatusByPatientId(int patientId);
    }
}
