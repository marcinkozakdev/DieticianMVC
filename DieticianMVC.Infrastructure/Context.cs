using DieticianMVC.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DieticianMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Dietician> Dieticianes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Dietician>()
                .HasMany(a=>a.)
                .HasForeignKey<>
        }

    }
}
