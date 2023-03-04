using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Domain.Model;

namespace DieticianMVC.Infrastructure.Repositories
{
    public class FoodPreferencesRepository : IFoodPreferencesRepository
    {
        private readonly Context _context;
        public FoodPreferencesRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<FoodPreferences> GetFoodPreferencesByPatientId(int patientId)
        {
            var foodPreferences = _context.FoodPreferences.Where(i => i.Id == patientId);
            return foodPreferences;
        }

        public FoodPreferences AddFoodPreferences(FoodPreferences foodPreferences)
        {
            _context.FoodPreferences.Add(foodPreferences);
            _context.SaveChanges();
            return foodPreferences;
        }

        public FoodPreferences UpdateFoodPreferences(FoodPreferences foodPreferences)
        {
            if (foodPreferences != null)
                _context.FoodPreferences.Update(foodPreferences);
            _context.SaveChanges();
            return foodPreferences;
        }

        public void DeleteFoodPreferences(int foodPreferencesId)
        {
            var foodPreferences = _context.FoodPreferences.FirstOrDefault(d => d.Id == foodPreferencesId);
            if (foodPreferences != null)
            {
                _context.FoodPreferences.Remove(foodPreferences);
                _context.SaveChanges();
            }
        }
    }
}
