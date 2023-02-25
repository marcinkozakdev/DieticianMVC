namespace DieticianMVC.Domain.Model
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime MealTime { get; set; }
        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
