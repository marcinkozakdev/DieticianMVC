using DieticianMVC.Domain.Model;

namespace DieticianMVC.Domain.Interfaces
{
    public interface IDieticianRepository
    {
        Dietician CreateDietician(Dietician dietician);
        Dietician GetDieticianById(int dieticianId);
        Dietician UpdateDietician(Dietician dietician);
        void DeleteDietician(int dieticianId);
    }
}
