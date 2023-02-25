namespace DieticianMVC.Domain.Model
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PatientId { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
