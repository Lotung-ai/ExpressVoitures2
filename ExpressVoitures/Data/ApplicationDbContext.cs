using ExpressVoitures.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace ExpressVoitures.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private IDbConnection DbConnection { get; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration config)
            : base(options)
        {
            DbConnection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Modele> Modeles { get; set; }
        public DbSet<Finition> Finitions { get; set; }
        public DbSet<Year> Years { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConnection.ConnectionString, providerOptions => providerOptions.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
               .HasMany(b => b.Modeles)
               .WithOne(cm => cm.Brand)
               .HasForeignKey(cm => cm.BrandId);

            modelBuilder.Entity<Modele>()
                .HasMany(cm => cm.Cars)
                .WithOne(c => c.Modele)
                .HasForeignKey(c => c.ModelId);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Brand)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.BrandId);

            modelBuilder.Entity<Car>()
               .HasOne(c => c.Year)
               .WithMany(y => y.Cars)
               .HasForeignKey(c => c.YearId);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Finition)
                .WithMany(f => f.Cars)
                .HasForeignKey(c => c.FinitionId);
        }
    }
}
