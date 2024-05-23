using ExpressVoitures.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>(),
                serviceProvider.GetRequiredService<IConfiguration>()))
            {
                // Vérifier si des marques existent déjà
                if (!context.Brands.Any())
                {
                    // Ajouter des marques
                    context.Brands.AddRange(
                        new Brand { Name = "Mazda" },
                        new Brand { Name = "Ford" },
                        new Brand { Name = "Toyota" },
                        new Brand { Name = "Honda" },
                        new Brand { Name = "BMW" }
                    );
                }

                // Vérifier si des années existent déjà
                if (!context.Years.Any())
                {
                    // Ajouter des années de 1990 à l'année actuelle
                    var currentYear = DateTime.Now.Year;
                    var years = new List<Year>();
                    for (int i = 1990; i <= currentYear; i++)
                    {
                        years.Add(new Year { Value = i });
                    }

                    context.Years.AddRange(years);
                }

                // Vérifier si des finitions existent déjà
                if (!context.Finitions.Any())
                {
                    // Ajouter des finitions
                    context.Finitions.AddRange(
                        new Finition { Name = "Base" },
                        new Finition { Name = "Sport" },
                        new Finition { Name = "Luxury" },
                        new Finition { Name = "Premium" }
                    );
                }

                // Vérifier si des modèles existent déjà
                if (!context.Modeles.Any())
                {
                    // Ajouter des modèles associés à des marques (assurez-vous que les marques existent)
                    var fordBrand = context.Brands.FirstOrDefault(b => b.Name == "Ford");
                    var toyotaBrand = context.Brands.FirstOrDefault(b => b.Name == "Toyota");

                    if (fordBrand != null)
                    {
                        context.Modeles.AddRange(
                            new Modele { Name = "Focus", BrandId = fordBrand.Id },
                            new Modele { Name = "Mustang", BrandId = fordBrand.Id }
                        );
                    }

                    if (toyotaBrand != null)
                    {
                        context.Modeles.AddRange(
                            new Modele { Name = "Corolla", BrandId = toyotaBrand.Id },
                            new Modele { Name = "Camry", BrandId = toyotaBrand.Id }
                        );
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
