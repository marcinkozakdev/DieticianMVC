using DieticianMVC.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DieticianMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BodyMeasurements> BodyMeasurements { get; set; }
        public DbSet<Dietician> Dieticianes { get; set; }
        public DbSet<Dish> Dishes { get; set; } 
        public DbSet<DislikedProduct> DislikedProducts { get; set; }
        public DbSet<FoodAllergiesAndIntolerances> FoodAllergiesAndIntolerances { get; set; }
        public DbSet<FoodPreferences> FoodPreferences { get; set; }
        public DbSet<HomeMeasure> HomeMeasures { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<LikedProduct> LikedProducts { get; set; }   
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientStatus> PatientStatuses { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Ingredient>()
                .HasOne(a => a.HomeMeasure).WithOne(a => a.Ingredient).HasForeignKey<HomeMeasure>(a=>a.IngredientId);

            builder.Entity<Dietician>()
                .HasMany(a => a.Patients).WithOne(a => a.Dietician).HasForeignKey(a => a.DieticianId);
                
        }

    }
}
