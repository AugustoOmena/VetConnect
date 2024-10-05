using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ClinicManagementSystem.Persistence.Context;

namespace ClinicManagementSystem.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>();

        builder.UseNpgsql("Host=localhost; Database=clinicmanagementsystem.api; Username=postgres; Password=123456");

        return new AppDbContext(builder.Options);
    }
}