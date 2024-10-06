using Microsoft.EntityFrameworkCore;
using VetConnect.Domain.Entities;

namespace VetConnect.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
    public DbSet<User> Users { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<ServiceHistory> ServiceHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=clinicmanagementsystem.api; Username=postgres; Password=123456", 
                b => b.MigrationsAssembly("VetConnect.Persistence"));
        }
    }
}
