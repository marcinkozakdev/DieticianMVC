using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Domain.Model;

namespace DieticianMVC.Infrastructure.Repositories
{
    public class MealRepository : IMealRepository
    {

        private readonly Context _context;
        public MealRepository(Context context)
        {
            _context = context;
        }

        public Meal GetMealById(int mealId)
        {
            var meal = _context.Meals.FirstOrDefault(i => i.Id == mealId);
            return meal;
        }

        public IQueryable<Meal> GetAllMealsByMenuId(int menuId)
        {
            var meals = _context.Meals.Where(i => i.MenuId == menuId);
            return meals;
        }

        public Meal AddMeal(Meal meal)
        {
            _context.Meals.Add(meal);
            _context.SaveChanges();
            return meal;
        }

        public Meal UpdateMeal(Meal meal)
        {
            if (meal != null)
                _context.Meals.Update(meal);
            _context.SaveChanges();
            return meal;
        }

        public void DeleteMeal(int mealId)
        {
            var meal = _context.Meals.FirstOrDefault(d => d.Id == mealId);
            if (meal != null)
            {
                _context.Meals.Remove(meal);
                _context.SaveChanges();
            }
        }
    }
}
