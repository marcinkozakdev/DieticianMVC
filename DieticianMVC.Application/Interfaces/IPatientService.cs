using DieticianMVC.Application.ViewModels.Patient;

namespace DieticianMVC.Application.Interfaces
{
    public interface IPatientService
    {
        ListPatientsForListVm GetAllPatientForList(int pageSize, int pageNumber, string searchString);
        int AddPatient(NewPatientVm patient);
        PatientDetailsVm GetPatientDetails(int idpatientId);
        void DeletePatient(int patientId);
        NewPatientVm GetPatientForEdit(int patientId);
        void UpdatePatient(NewPatientVm patient);
        int AddBodyMeasurements(NewBodyMeasurementsVm bodyMeasurements);
        IQueryable<BodyMeasurementsForListVm> GetBodyMeasurementsByPatient(int patientId);
        NewBodyMeasurementsVm GetBodyMeasurementsForEdit(int bodyMeasurementsId);
        void UpdateBodyMeasurements(NewBodyMeasurementsVm bodyMeasurements);
        void DeleteBodyMeasurements(int bodyMeasurementsId);
    }
}
