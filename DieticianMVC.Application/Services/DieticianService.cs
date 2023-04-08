using AutoMapper;
using DieticianMVC.Application.ViewModels.Patient;
using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Domain.Model;

namespace DieticianMVC.Application.Services
{
    public class DieticianService
    {
        private readonly IDieticianRepository _dieticianRepository;
        private readonly IMapper _mapper;

        public DieticianService(IDieticianRepository dieticianRepository, IMapper mapper)
        {
            _dieticianRepository = dieticianRepository;
            _mapper = mapper;
        }

        public int CreateDietician(NewDieticianVm dieticianVm)
        {
            var dietician = _mapper.Map<Dietician>(dieticianVm);
            var id = _dieticianRepository.CreateDietician(dietician);
            return id;
        }

        public void DeleteBodyMeasurements(int bodyMeasurementsId)
        {
            _bodyMeasurementsRepository.DeleteBodyMeasurements(bodyMeasurementsId);
        }

        public void DeletePatient(int patientId)
        {
            _patientRepository.DeletePatient(patientId);
        }
       
        public NewBodyMeasurementsVm GetBodyMeasurementsForEdit(int bodyMeasurementsId)
        {
            var bodyMeasurements = _bodyMeasurementsRepository.GetBodyMeasurementsById(bodyMeasurementsId);
            var bodyMeasurementsVm = _mapper.Map<NewBodyMeasurementsVm>(bodyMeasurements);
            return bodyMeasurementsVm;
        }

        public PatientDetailsVm GetPatientDetails(int patientId)
        {
            var patient = _patientRepository.GetPatient(patientId);
            var patientVm = _mapper.Map<PatientDetailsVm>(patient);
            return patientVm;
        }

        public NewPatientVm GetPatientForEdit(int patientId)
        {
            var patient = _patientRepository.GetPatient(patientId);
            var patientVm = _mapper.Map<NewPatientVm>(patient);
            return patientVm;
        }

        public void UpdateBodyMeasurements(NewBodyMeasurementsVm bodyMeasurementsVm)
        {
            var bodyMeasurements = _mapper.Map<BodyMeasurements>(bodyMeasurementsVm);
            _bodyMeasurementsRepository.UpdateBodyMeasurements(bodyMeasurements);
        }

        public void UpdatePatient(NewPatientVm patientVm)
        {
            var patient = _mapper.Map<Patient>(patientVm);
            _patientRepository.UpdatePatient(patient);
        }

        public void UpdatePatientDetails(PatientDetailsVm patientVm)
        {
            var patient = _mapper.Map<Patient>(patientVm);
            _patientRepository.UpdatePatient(patient);
        }
    }
}
