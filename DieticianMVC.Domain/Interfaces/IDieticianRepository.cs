using DieticianMVC.Domain.Model;

namespace DieticianMVC.Domain.Interfaces
{
    public interface IDieticianRepository
    {
        int CreateDietician(Dietician dieticianId);
        Dietician GetDieticianById(int dieticianId);
        Dietician UpdateDietician(Dietician dietician);
        void DeleteDietician(int dieticianId);
    }
}
