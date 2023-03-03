using DieticianMVC.Domain.Model;

namespace DieticianMVC.Domain.Interfaces
{
    public interface IPatientRepository
    {
        Patient AddPatient(Patient patient);
        Patient GetPatientById(int patientId);
        IQueryable<Patient> GetPatientByDieticianId(int dieticianId);
        Patient UpdatePatient(Patient patient);
        void DeletePatient(int patientId);
    }
}
