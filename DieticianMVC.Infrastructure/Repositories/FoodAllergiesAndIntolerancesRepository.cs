using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Domain.Model;

namespace DieticianMVC.Infrastructure.Repositories
{
    public class FoodAllergiesAndIntolerancesRepository : IFoodAllergiesAndIntolerancesRepository
    {
        private readonly Context _context;
        public FoodAllergiesAndIntolerancesRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<FoodAllergiesAndIntolerances> GetDislikedProductsByPatientId(int patientId)
        {
            var foodAllergiesAndIntolerances = _context.FoodAllergiesAndIntolerances.Where(i => i.Id == patientId);
            return foodAllergiesAndIntolerances;
        }

        public FoodAllergiesAndIntolerances AddDislikedProduct(FoodAllergiesAndIntolerances foodAllergiesAndIntolerances)
        {
            _context.FoodAllergiesAndIntolerances.Add(foodAllergiesAndIntolerances);
            _context.SaveChanges();
            return foodAllergiesAndIntolerances;
        }

        public FoodAllergiesAndIntolerances UpdateDislikedProduct(FoodAllergiesAndIntolerances foodAllergiesAndIntolerances)
        {
            if (foodAllergiesAndIntolerances != null)
                _context.FoodAllergiesAndIntolerances.Update(foodAllergiesAndIntolerances);
            _context.SaveChanges();
            return foodAllergiesAndIntolerances;
        }

        public void DeleteDislikedProduct(int foodAllergiesAndIntolerancesId)
        {
            var foodAllergiesAndIntolerances = _context.FoodAllergiesAndIntolerances.FirstOrDefault(d => d.Id == foodAllergiesAndIntolerancesId);
            if (foodAllergiesAndIntolerances != null)
            {
                _context.FoodAllergiesAndIntolerances.Remove(foodAllergiesAndIntolerances);
                _context.SaveChanges();
            }
        }
    }
}
