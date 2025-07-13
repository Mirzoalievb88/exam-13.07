using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Car>  Cars { get; set; }
    public DbSet<Customers>  Customers { get; set; }
    public DbSet<Branches>  Branches { get; set; }
    public DbSet<Rentals>  Rentals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customers>()
            .HasMany(x => x.Rentals)
            .WithOne(r => r.Car)
            .HasForeignKey(r => r.CarId);
        
        modelBuilder.Entity<Branches>()
            .HasMany(b => b.Cars)
            .WithOne(c => c.Branch)
            .HasForeignKey(c => c.Branch);
        
        modelBuilder.Entity<Rentals>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.Rentals)
            .HasForeignKey(c => c.CustomerId);
    }
}