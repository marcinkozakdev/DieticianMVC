using DieticianMVC.Domain.Model;

namespace DieticianMVC.Domain.Interfaces
{
    public interface IDieticianRepository
    {
        public Dietician GetDieticianById(int dieticianId);
        public IQueryable<Dietician> GetAllDieticians();
        public int CreateDietician(Dietician dietician);
        public Dietician UpdateDietician(Dietician dietician);
        public void DeleteDietician(int dieticianId);
        public Dietician GetDieticianByUserId(string id);
    }
}
