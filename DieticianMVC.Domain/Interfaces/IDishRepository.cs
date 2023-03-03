using DieticianMVC.Domain.Model;

namespace DieticianMVC.Domain.Interfaces
{
    public interface IDishRepository
    {
        Dish GetDishById(int dishId);
        Dish AddDish(Dish dish);
        Dish UpdateDish(Dish dish);
        void DeleteDish(int dishId);
    }
}
