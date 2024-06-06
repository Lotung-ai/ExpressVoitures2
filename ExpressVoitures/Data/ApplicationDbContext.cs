using ExpressVoitures.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Brand>()
               .HasMany(b => b.Modeles)
               .WithOne(cm => cm.Brand)
               .HasForeignKey(cm => cm.BrandId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Modele>()
                .HasMany(cm => cm.Cars)
                .WithOne(c => c.Modele)
                .HasForeignKey(c => c.ModelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Brand)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Car>()
               .HasOne(c => c.Year)
               .WithMany(y => y.Cars)
               .HasForeignKey(c => c.YearId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Car>()
               .HasOne(c => c.Modele)
               .WithMany(y => y.Cars)
               .HasForeignKey(c => c.ModelId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Finition)
                .WithMany(f => f.Cars)
                .HasForeignKey(c => c.FinitionId)
                .OnDelete(DeleteBehavior.Restrict);

         
            // Ajouter les années de 1990 à aujourd'hui
            var currentYear = DateTime.Now.Year;
            var years = new List<Year>();
            for (int i = 1990; i <= currentYear; i++)
            {
                years.Add(new Year { Id = i - 1989, Value = i });
            }

            modelBuilder.Entity<Year>().HasData(years);

            // Ajouter des finitions
            modelBuilder.Entity<Finition>().HasData(
                new Finition { Id = 1, Name = "Base" },
                new Finition { Id = 2, Name = "Sport" },
                new Finition { Id = 3, Name = "Luxury" },
                new Finition { Id = 4, Name = "Premium" }
            );

            // Ajouter des marques
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Mazda" },
                new Brand { Id = 2, Name = "Ford" },
                new Brand { Id = 3, Name = "Toyota" },
                new Brand { Id = 4, Name = "Honda" },
                new Brand { Id = 5, Name = "BMW" }
            );

            // Ajouter des modèles associés à des marques
            modelBuilder.Entity<Modele>().HasData(
                new Modele { Id = 1, Name = "Focus", BrandId = 2 },
                new Modele { Id = 2, Name = "Mustang", BrandId = 2 },
                new Modele { Id = 3, Name = "Corolla", BrandId = 3 },
                new Modele { Id = 4, Name = "Camry", BrandId = 3 },
                new Modele { Id = 5, Name = "2", BrandId = 1 },
                new Modele { Id = 6, Name = "3", BrandId = 1 }
            ); 
        }
      
    }
}
