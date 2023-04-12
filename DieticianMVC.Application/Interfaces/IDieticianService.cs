using DieticianMVC.Application.ViewModels.Dietician;

namespace DieticianMVC.Application.Interfaces
{
    public interface IDieticianService
    {
        int CreateDietician(NewDieticianVm dieticianVm);
        void DeleteDietician(int dieticianId);
        DieticianDetailsVm GetDieticianDetails(int dieticianId);
        NewDieticianVm GetDieticianForEdit(int dieticianId);
        void UpdateDietician(NewDieticianVm dieticianVm);
        void UpdateDieticianDetails(DieticianDetailsVm dieticianVm);
    }
}
