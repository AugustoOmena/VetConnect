using System.Reflection;
using Microsoft.EntityFrameworkCore;
using VetConnect.Data.Maps;

namespace VetConnect.Data.Utils;

 public class DataContext : DbContext {
        public DbContext Context { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
            Context = this;
        }

        protected override void OnModelCreating(ModelBuilder mb) {
            mb.ApplyConfigurationsFromAssembly(typeof(UserMap).GetTypeInfo().Assembly);
       
        }
    }