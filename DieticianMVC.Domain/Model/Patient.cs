namespace DieticianMVC.Domain.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DieticianId { get; set; }
        public virtual ICollection<FoodPreferences> FoodPreferences { get; set; }
        public virtual ICollection<FoodAllergiesAndIntolerances> FoodAllergiesAndIntolerances { get; set; }
        public virtual ICollection<DislikedProduct> DislikedProducts { get; set; }
        public virtual ICollection<LikedProduct> LikedProducts { get; set;}
        public virtual ICollection<BodyMeasurements> BodyMeasurements { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual PatientStatus PatientStatus { get; set; }
        public virtual Dietician Dietician { get; set; }
    }
}
