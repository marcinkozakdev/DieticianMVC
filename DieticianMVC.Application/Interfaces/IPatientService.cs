﻿using DieticianMVC.Application.ViewModels.Patient;

namespace DieticianMVC.Application.Interfaces
{
    public interface IPatientService
    {
        ListPatientsForListVm GetAllPatientsForList(int pageSize, int pageNumber, string searchString);
        int AddPatient(NewPatientVm patient);
        PatientDetailsVm GetPatientDetails(int patientId);
        void DeletePatient(int patientId);
        NewPatientVm GetPatientForEdit(int patientId);
        void UpdatePatient(NewPatientVm patient);
        void UpdatePatientDetails(PatientDetailsVm patient);

        int AddBodyMeasurements(NewBodyMeasurementsVm bodyMeasurements);
        IQueryable<BodyMeasurementsForListVm> GetBodyMeasurementsByPatient(int patientId);
        NewBodyMeasurementsVm GetBodyMeasurementsForEdit(int bodyMeasurementsId);
        void UpdateBodyMeasurements(NewBodyMeasurementsVm bodyMeasurements);
        void DeleteBodyMeasurements(int bodyMeasurementsId);
    }
}
