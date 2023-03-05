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

            builder.Entity<Dietician>()
                .HasMany(a => a.Patients).WithOne(a => a.Dietician).HasForeignKey(a => a.DieticianId);

            builder.Entity<BodyMeasurements>(eb =>
            {
                eb.Property(a => a.Weight).HasPrecision(4, 1);
                eb.Property(a => a.Height).HasPrecision(4, 1);
                eb.Property(a => a.WaistCircumference).HasPrecision(4, 1);
                eb.Property(a => a.HipCircumference).HasPrecision(4, 1);
                eb.Property(a => a.ChestCircumference).HasPrecision(4, 1);
                eb.Property(a => a.ArmCircumference).HasPrecision(4, 1);
                eb.Property(a => a.CalfCircumference).HasPrecision(4, 1);
                eb.Property(a => a.ThighCircumference).HasPrecision(4, 1);
                eb.Property(a => a.TotalMuscleMass).HasPrecision(4, 1);
                eb.Property(a => a.SkeletalMuscleMass).HasPrecision(4, 1);
                eb.Property(a => a.BodyFatMass).HasPrecision(4, 1);
                eb.Property(a => a.TotalWaterContent).HasPrecision(4, 1);
                eb.Property(a => a.BoneMineralContent).HasPrecision(4, 1);
                eb.Property(a => a.AdiposeTissue).HasPrecision(4, 1);
                eb.Property(a => a.BasalMetabolism).HasPrecision(4, 1);
            });

            builder.Entity<HomeMeasure>(eb =>
            {
                eb.Property(a => a.Value).HasPrecision(4, 1);
            });

            builder.Entity<Ingredient>(eb =>
            {
                eb.Property(a => a.Protein).HasPrecision(4, 1);
                eb.Property(a => a.Fat).HasPrecision(4, 1);
                eb.Property(a => a.Carbohydrates).HasPrecision(4, 1);
                eb.Property(a => a.Fiber).HasPrecision(4, 1);
                eb.Property(a => a.GlycemicIndex).HasPrecision(4, 1);
                eb.Property(a => a.GlycemicLoad).HasPrecision(4, 1);
            });
        }
    }
}


