using DieticianMVC.Domain.Model;

namespace DieticianMVC.Domain.Interfaces
{
    public interface IMealRepository
    {
        Meal GetMealById(int mealId);
        IQueryable<Meal> GetAllMealsByMenuId(int menuId);
        Meal AddMeal(Meal meal);
        Meal UpdateMeal(Meal meal);
        void DeleteMeal(int mealId);
    }
}
