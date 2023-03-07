using AutoMapper;
using AutoMapper.QueryableExtensions;
using DieticianMVC.Application.Interfaces;
using DieticianMVC.Application.ViewModels.Patient;
using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Domain.Model;

namespace DieticianMVC.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public int AddPatient(NewPatientVm patientVm)
        {
            var patient = _mapper.Map<Patient>(patientVm);
            var id = _patientRepository.AddPatient(patient);
            return id;
        }

        public ListPatientForListVm GetAllPatientForList()
        {
            var patients = _patientRepository.GetAllActivePatients()
                .ProjectTo<PatientForListVm>(_mapper.ConfigurationProvider).ToList();
            var patientList = new ListPatientForListVm()
            {
                Patients = patients,
                Count = patients.Count
            };
            return patientList;
        }

        public PatientDetailsVm GetPatientDetails(int patientId)
        {
            var patient = _patientRepository.GetPatient(patientId);
            var patientVm = _mapper.Map<PatientDetailsVm>(patient);

            patientVm.Id = patient.Id;
            patientVm.FirstName = patient.FirstName;
            patientVm.LastName = patient.LastName;
            patientVm.EmailAddress = patient.EmailAddress;
            patientVm.PhoneNumber = patient.PhoneNumber;
            patientVm.Sex = patient.Sex;
            patientVm.DateOfBirth = patient.DateOfBirth;
            patientVm.FoodPreferences = new List<FoodPreferencesForListVm>();
            patientVm.LikedProducts = new List<LikedProductForListVm>();
            patientVm.DislikedProducts = new List<DislikedProductForListVm>();
            patientVm.FoodAllergiesAndIntolerances = new List<FoodAllergiesAndIntolerancesForListVm>();

            foreach(var foodPreference in patient.FoodPreferences)
            {
                var add = new FoodPreferencesForListVm()
                {
                    Id = foodPreference.Id,
                    Name = foodPreference.Name,
                };
                patientVm.FoodPreferences.Add(add);
            }

            foreach (var likeProduct in patient.LikedProducts)
            {
                var add = new LikedProductForListVm()
                {
                    Id = likeProduct.Id,
                    Name = likeProduct.Name,
                };
                patientVm.LikedProducts.Add(add);
            }

            foreach (var dislikeProduct in patient.DislikedProducts)
            {
                var add = new DislikedProductForListVm()
                {
                    Id = dislikeProduct.Id,
                    Name = dislikeProduct.Name,
                };
                patientVm.DislikedProducts.Add(add);
            }

            foreach (var foodAllergiesAndIntolerances in patient.FoodAllergiesAndIntolerances)
            {
                var add = new FoodAllergiesAndIntolerancesForListVm()
                {
                    Id = foodAllergiesAndIntolerances.Id,
                    Name = foodAllergiesAndIntolerances.Name,
                };
                patientVm.FoodAllergiesAndIntolerances.Add(add);
            }
            return patientVm;
        }
    }
}
