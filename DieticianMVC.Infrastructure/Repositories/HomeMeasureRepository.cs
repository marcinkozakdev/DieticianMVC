using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Domain.Model;

namespace DieticianMVC.Infrastructure.Repositories
{
    public class HomeMeasureRepository : IHomeMeasureRepository
    {
        private readonly Context _context;
        public HomeMeasureRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<HomeMeasure> GetAllHomeMeasure()
        {
            var homeMeasures = _context.HomeMeasures.ToList();
            return homeMeasures;
        }

        public HomeMeasure AddHomeMeasure(HomeMeasure homeMeasure)
        {
            _context.HomeMeasures.Add(homeMeasure);
            _context.SaveChanges();
            return homeMeasure;
        }

        public HomeMeasure UpdateHomeMeasure(HomeMeasure homeMeasure)
        {
            if (homeMeasure != null)
                _context.HomeMeasures.Update(homeMeasure);
            _context.SaveChanges();
            return homeMeasure;
        }

        public void DeleteHomeMeasure(int homeMeasureId)
        {
            var homeMeasure = _context.HomeMeasures.FirstOrDefault(d => d.Id == homeMeasureId);
            if (homeMeasure != null)
            {
                _context.HomeMeasures.Remove(homeMeasure);
                _context.SaveChanges();
            }
        }
    }
}
