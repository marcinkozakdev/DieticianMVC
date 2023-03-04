using DieticianMVC.Domain.Model;

namespace DieticianMVC.Domain.Interfaces
{
    public interface IIngredientRepository
    {
        IEnumerable<Ingredient> GetAllIngredients();
        IQueryable<Ingredient> GetAllIngredientsByDishId(int dishId);
        Ingredient AddHomeMeasure(Ingredient ingredient);
        Ingredient UpdateHomeMeasure(Ingredient ingredient);
        void DeleteHomeMeasure(int ingredientId);
    }
}
