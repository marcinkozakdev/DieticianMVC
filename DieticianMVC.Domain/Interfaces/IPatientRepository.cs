using DieticianMVC.Domain.Model;

namespace DieticianMVC.Domain.Interfaces
{
    public interface IPatientRepository
    {
        int AddPatient(Patient patient);
        Patient GetPatient(int patientId);
        IQueryable<Patient> GetPatientByDieticianId(int dieticianId);
        IQueryable<Patient> GetAllActivePatients();
        Patient UpdatePatient(Patient patient);
        void DeletePatient(int patientId);
    }
}
