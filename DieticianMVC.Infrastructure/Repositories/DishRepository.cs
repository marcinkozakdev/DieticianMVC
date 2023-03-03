using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Domain.Model;

namespace DieticianMVC.Infrastructure.Repositories
{
    public class DishRepository : IDishRepository
    {

        private readonly Context _context;
        public DishRepository(Context context)
        {
            _context = context;
        }

        public Dish GetDishById(int dishId)
        {
            var dish = _context.Dishes.FirstOrDefault(i => i.Id == dishId);
            return dish;
        }

        public Dish AddDish(Dish dish)
        {
            _context.Dishes.Add(dish);
            _context.SaveChanges();
            return dish;
        }

        public Dish UpdateDish(Dish dish)
        {
            if (dish != null)
                _context.Dishes.Update(dish);
            _context.SaveChanges();
            return dish;
        }

        public void DeleteDish(int dishId)
        {
            var dish = _context.Dishes.FirstOrDefault(d => d.Id == dishId);
            if (dish != null)
            {
                _context.Dishes.Remove(dish);
                _context.SaveChanges();
            }
        }
    }
}
