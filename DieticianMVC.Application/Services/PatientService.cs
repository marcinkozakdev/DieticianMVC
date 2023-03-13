using AutoMapper;
using AutoMapper.QueryableExtensions;
using DieticianMVC.Application.Interfaces;
using DieticianMVC.Application.ViewModels.Patient;
using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Domain.Model;
using System.Security.Cryptography.X509Certificates;

namespace DieticianMVC.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IBodyMeasurementsRepository _bodyMeasurementsRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IBodyMeasurementsRepository bodyMeasurementsRepository ,IMapper mapper)
        {
            _patientRepository = patientRepository;
            _bodyMeasurementsRepository = bodyMeasurementsRepository;
            _mapper = mapper;
        }

        public int AddBodyMeasurements(NewBodyMeasurementsVm bodyMeasurementsVm)
        {
            var bodyMeasurements = _mapper.Map<BodyMeasurements>(bodyMeasurementsVm);
            var id = _bodyMeasurementsRepository.AddBodyMeasurements(bodyMeasurements);
            return id;
        }

        public int AddPatient(NewPatientVm patientVm)
        {
            var patient = _mapper.Map<Patient>(patientVm);
            var id = _patientRepository.AddPatient(patient);
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

        public ListPatientsForListVm GetAllPatientsForList(int pageSize, int pageNumber, string searchString)
        {
            var patients = _patientRepository.GetAllActivePatients()
                .Where(p=>p.FirstName.ToLower().Contains(searchString.ToLower()))
                .ProjectTo<PatientForListVm>(_mapper.ConfigurationProvider).ToList();

            var patientToShow = patients.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();

            var patientList = new ListPatientsForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNumber,
                SearchString = searchString,
                Patients = patientToShow,
                Count = patients.Count
            };
            return patientList;
        }

        public IQueryable<BodyMeasurementsForListVm> GetBodyMeasurementsByPatient(int patientId)
        {
            var bodyMeasurementsVm = _bodyMeasurementsRepository.GetBodyMeasurementsByPatientId(patientId).ProjectTo<BodyMeasurementsForListVm>(_mapper.ConfigurationProvider);
            return bodyMeasurementsVm;
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
