using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Orders.Shared.Entites;

namespace Orders.backend.Data;

    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Country> _Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
         { 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
            
   
        }
    }
