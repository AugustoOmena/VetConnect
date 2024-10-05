using System.Reflection;
using ClinicManagementSystem.Data.Maps;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Data.Utils;

 public class DataContext : DbContext {
        public DbContext Context { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
            Context = this;
        }

        protected override void OnModelCreating(ModelBuilder mb) {
            mb.ApplyConfigurationsFromAssembly(typeof(UserMap).GetTypeInfo().Assembly);
       
        }
    }