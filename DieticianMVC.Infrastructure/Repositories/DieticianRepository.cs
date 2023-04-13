using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace DieticianMVC.Infrastructure.Repositories
{
    public class DieticianRepository : IDieticianRepository
    {
        private readonly Context _context;

        public DieticianRepository(Context context)
        {
            _context = context;
        }

        public Dietician GetDieticianById(int id)
        {
            var dietician = _context.Dieticianes.FirstOrDefault(i => i.Id == id);
            return dietician;
        }

        public IQueryable<Dietician> GetAllDieticians()
        {
            var dieticians = _context.Dieticianes.AsNoTracking();
            return dieticians;
        }

        public int CreateDietician(Dietician dietician)
        {
            _context.Dieticianes.Add(dietician);
            _context.SaveChanges();
            return dietician.Id;
        }

        public Dietician UpdateDietician(Dietician dietician)
        {
            if (dietician != null)
                _context.Dieticianes.Update(dietician);
            _context.SaveChanges();
            return dietician;
        }

        public void DeleteDietician(int dieticianId)
        {
            var dietician = _context.Dieticianes.FirstOrDefault(d => d.Id == dieticianId);
            if (dietician != null)
            {
                _context.Dieticianes.Remove(dietician);
                _context.SaveChanges();
            }
        }

        public Dietician GetDieticianByUserId(string id)
        {
            var dietician = _context.Dieticianes.AsNoTracking()
                 .Include(e => e.Addresses)
                .FirstOrDefault(e => e.UserId == id);
            return dietician;
        }
    }
}
