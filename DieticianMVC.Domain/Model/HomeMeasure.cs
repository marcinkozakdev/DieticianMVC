namespace DieticianMVC.Domain.Model
{
    public class HomeMeasure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
