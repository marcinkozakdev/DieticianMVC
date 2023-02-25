namespace DieticianMVC.Domain.Model
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime PreparationTime { get; set; }
        public string Description { get; set; }
        public string DificultyLevel { get; set; }
        public int Portions { get; set; }
        public int MealId { get; set; }
        public virtual Meal Meals { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }    
    }
}
