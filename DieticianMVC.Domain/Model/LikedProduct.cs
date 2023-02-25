namespace DieticianMVC.Domain.Model
{
    public class LikedProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
