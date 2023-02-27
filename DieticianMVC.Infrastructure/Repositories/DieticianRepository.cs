using DieticianMVC.Domain.Model;

namespace DieticianMVC.Infrastructure.Repositories
{
    public class DieticianRepository
    { 
        private readonly Context _context;
        public DieticianRepository(Context context)
        {
            _context = context;
        }

        public void DeleteDietician(int dieticianId)
        {
            var dietician = _context.Dieticianes.Find(dieticianId);
            if (dietician != null)
            {
                _context.Dieticianes.Remove(dietician);
                _context.SaveChanges();
            }
        }

        public int CreateDietician(Dietician dietician)
        {
            _context.Dieticianes.Add(dietician);
            _context.SaveChanges();
            return dietician.Id;
        }

        public Dietician GetDieticianById(int dieticianId)
        {
            var dietician = _context.Dieticianes.FirstOrDefault(i => i.Id == dieticianId);
            return dietician;
        }
    }
}
