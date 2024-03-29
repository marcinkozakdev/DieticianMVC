﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using DieticianMVC.Application.Interfaces;
using DieticianMVC.Application.ViewModels.Dietician;
using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Domain.Model;
using System.Linq;


namespace DieticianMVC.Application.Services
{
    public class DieticianService : IDieticianService
    {
        private readonly IDieticianRepository _dieticianRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public DieticianService(IDieticianRepository dieticianRepository, IAddressRepository addressRepository, IMapper mapper)
        {
            _dieticianRepository = dieticianRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public int CreateDietician(NewDieticianVm dieticianVm)
        {
            var dietician = _mapper.Map<Dietician>(dieticianVm);
            var id = _dieticianRepository.CreateDietician(dietician);
            return id;
        }

        public ListDieticianForListVm GetAllDieticiansForList()
        {
            var dieticians = _dieticianRepository.GetAllDieticians().ProjectTo<DieticianForListVm>(_mapper.ConfigurationProvider).ToList();
            var dieticiansVm = new ListDieticianForListVm()
            {
                Dieticians = dieticians,
                Count = dieticians.Count
            };
            return dieticiansVm;
        }

        public Dietician GetDieticianById(int id)
        {
            var dietician = _dieticianRepository.GetDieticianById(id);
            return dietician;
        }

        public DieticianDetailsVm GetDieticianDetails(int dieticianId)
        {
            var dietician = _dieticianRepository.GetDieticianById(dieticianId);
            var dieticianVm = _mapper.Map<DieticianDetailsVm>(dietician);
            if(dieticianVm !=null)
            {
                dieticianVm.Addresses = _addressRepository.GetAddressByDietician(dieticianId)
                    .AsQueryable().ProjectTo<AddressForListVm>
                    (_mapper.ConfigurationProvider).ToList();
            }
            return dieticianVm;
        }
        public DieticianDetailsVm GetDieticianDetails(string userId)
        {
            var dietician = _dieticianRepository.GetDieticianByUserId(userId);
            var dieticianVm = GetDieticianDetails(dietician.Id);
            return dieticianVm;
        }

        public void DeleteDietician(int dieticianId)
        {
            _dieticianRepository.DeleteDietician(dieticianId);
        }

        public NewDieticianVm GetDieticianForEdit(string id)
        {
            var user = _dieticianRepository.GetDieticianByUserId(id);
            var dietician = _dieticianRepository.GetDieticianById(user.Id);
            var dieticianVm = _mapper.Map<NewDieticianVm>(dietician);
            return dieticianVm;
        }

        public void UpdateDietician(NewDieticianVm dieticianVm)
        {
            var dietician = _mapper.Map<Dietician>(dieticianVm);
            _dieticianRepository.UpdateDietician(dietician);
        }

        public void UpdateDieticianDetails(DieticianDetailsVm dieticianVm)
        {
            var dietician = _mapper.Map<Dietician>(dieticianVm);
            _dieticianRepository.UpdateDietician(dietician);
        }

        public Address AddAddress(NewAddressVm addressVm)
        {
            var address = _mapper.Map<Address>(addressVm);
            var id = _addressRepository.AddAddress(address);
            return id;
        }
        public Address GetAddressById(int addressId)
        {
            var address = _addressRepository.GetAddressById(addressId);
            return address;
        }
        public NewAddressVm GetAddressForEdit(int addressId)
        {
            var address = _addressRepository.GetAddressById(addressId);
            var addressVm = _mapper.Map<NewAddressVm>(address);
            return addressVm;
        }
        public void UpdateAddress(NewAddressVm addressVm)
        {
            var address=_mapper.Map<Address>(addressVm);
            _addressRepository.UpdateAddress(address);
        }

        public void DeleteAddress(int addressId)
        {
            _addressRepository.DeleteAddress(addressId);
        }
        public IQueryable<AddressForListVm> GetAddressByDietician(int id)
        {
            var addresVm = _addressRepository.GetAddressByDietician(id).ProjectTo<AddressForListVm>(_mapper.ConfigurationProvider);
            return addresVm;
        }

        public Dietician GetDieticianByUserId(string id)
        {
            var dietician = _dieticianRepository.GetDieticianByUserId(id);
            return dietician;
        }

        public bool CheckIfDieticianExist(string id)
        {
            return _dieticianRepository.GetDieticianByUserId(id) == null;
        }
    }
}
