using DieticianMVC.Domain.Model;

namespace DieticianMVC.Domain.Interfaces
{
    public interface IPatientRepository
    {
        void DeletePatient(int patientId);
        int AddPatient(Patient patient);
        IQueryable<Patient> GetPatientByDieticianId(int dieticianId);
        Patient GetPatientById(int patientId);
    }
}
