using DieticianMVC.Application.ViewModels.Dietician;
using DieticianMVC.Domain.Model;

namespace DieticianMVC.Application.Interfaces
{
    public interface IDieticianService
    {
        int CreateDietician(NewDieticianVm dieticianVm);
        Dietician GetDieticianById(int id);
        ListDieticianForListVm GetAllDieticiansForList();
        DieticianDetailsVm GetDieticianDetails(string dieticianId);
        void DeleteDietician(int dieticianId);
        NewDieticianVm GetDieticianForEdit(string dieticianId);
        void UpdateDietician(NewDieticianVm dieticianVm);
        void UpdateDieticianDetails(DieticianDetailsVm dieticianVm);
        Address AddAddress(NewAddressVm addressVm);
        Address GetAddressById(int addressId);
        NewAddressVm GetAddressForEdit(int addressId);
        void UpdateAddress(NewAddressVm addressVm);
        void DeleteAddress(int addressId);
        IQueryable<AddressForListVm> GetAddressByDietician(int id);
        Dietician GetDieticianByUserId(string id);
        bool CheckIfDieticianExist(string id);
    }
}
