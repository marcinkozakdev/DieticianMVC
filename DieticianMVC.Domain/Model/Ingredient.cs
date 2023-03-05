namespace DieticianMVC.Domain.Model
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Energy { get; set; }
        public decimal Protein { get; set; }
        public decimal Fat { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fiber { get; set; }
        public decimal GlycemicIndex { get; set; }
        public decimal GlycemicLoad { get; set; }
        public int DishId { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }
        public virtual ICollection<HomeMeasure> HomeMeasures { get; set; }
    }
}
