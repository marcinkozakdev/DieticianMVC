using AutoMapper;
using DieticianMVC.Application.ViewModels.Dietician;
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

        public void DeleteDietician(int dieticianId)
        {
            _dieticianRepository.DeleteDietician(dieticianId);
        }

        public DieticianDetailsVm GetDieticianDetails(int dieticianId)
        {
            var dietician = _dieticianRepository.GetDieticianById(dieticianId);
            var dieticianVm = _mapper.Map<DieticianDetailsVm>(dietician);
            return dieticianVm;
        }

        public NewDieticianVm GetDieticianForEdit(int dieticianId)
        {
            var dietician = _dieticianRepository.GetDieticianById(dieticianId);
            var dieticianVm = _mapper.Map<NewDieticianVm>(dietician);
            return dieticianVm;
        }


        public void UpdatePatient(NewDieticianVm dieticianVm)
        {
            var dietician = _mapper.Map<Dietician>(dieticianVm);
            _dieticianRepository.UpdateDietician(dietician);
        }

        public void UpdatePatientDetails(DieticianDetailsVm dieticianVm)
        {
            var dietician = _mapper.Map<Dietician>(dieticianVm);
            _dieticianRepository.UpdateDietician(dietician);
        }
    }
}
