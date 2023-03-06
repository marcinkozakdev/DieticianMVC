using DieticianMVC.Application.ViewModels.Patient;

namespace DieticianMVC.Application.Interfaces
{
    public interface IPatientService
    {
        ListPatientForListVm GetAllPatientForList();
        int AddPatient(NewPatientVm patient);
        PatientDetailsVm GetPatientDetails(int patientId);
    }
}
