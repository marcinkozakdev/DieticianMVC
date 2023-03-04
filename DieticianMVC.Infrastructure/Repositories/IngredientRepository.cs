using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Domain.Model;

namespace DieticianMVC.Infrastructure.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly Context _context;
        public IngredientRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Ingredient> GetAllIngredients()
        {
            var ingredients = _context.Ingredients.ToList();
            return ingredients;
        }

        public IQueryable<Ingredient> GetAllIngredientsByDishId(int dishId)
        {
            var ingredients = _context.Ingredients.Where(i=>i.DishId == dishId);
            return ingredients;
        }

        public Ingredient AddHomeMeasure(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
            return ingredient;
        }

        public Ingredient UpdateHomeMeasure(Ingredient ingredient)
        {
            if (ingredient != null)
                _context.Ingredients.Update(ingredient);
            _context.SaveChanges();
            return ingredient;
        }

        public void DeleteHomeMeasure(int ingredientId)
        {
            var ingredient = _context.Ingredients.FirstOrDefault(d => d.Id == ingredientId);
            if (ingredient != null)
            {
                _context.Ingredients.Remove(ingredient);
                _context.SaveChanges();
            }
        }
    }
}
