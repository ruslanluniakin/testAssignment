using Microsoft.EntityFrameworkCore;

namespace testAssignment.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated(); 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OwnerCar>()
                .HasKey(t => new { t.OwnerId, t.CarId });

            modelBuilder.Entity<OwnerCar>()
                .HasOne(sc => sc.Owner)
                .WithMany(s => s.OwnerCars)
                .HasForeignKey(sc => sc.OwnerId);

            modelBuilder.Entity<OwnerCar>()
                .HasOne(sc => sc.Car)
                .WithMany(c => c.OwnerCars)
                .HasForeignKey(sc => sc.CarId);
        }
    }
}
