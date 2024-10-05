using Microsoft.EntityFrameworkCore;
using ClinicManagementSystem.Domain.Entities;

namespace ClinicManagementSystem.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=clinicmanagementsystem.api; Username=postgres; Password=123456", 
                b => b.MigrationsAssembly("ClinicManagementSystem.Persistence"));
        }
    }
}
