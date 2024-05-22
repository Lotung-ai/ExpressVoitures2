using ExpressVoitures.Data;
using ExpressVoitures.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Models.Repositories
{
    public class ModeleRepository:IModeleRepository
    {  

            private readonly ApplicationDbContext _context;

            public ModeleRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public IEnumerable<SelectListItem> GetModels()
            {
                // Récupérer les marques depuis la base de données
                var models = _context.Modeles
                    .Select(b => new SelectListItem
                    {
                        Value = b.Id.ToString(),
                        Text = b.Name
                    })
                    .ToList();

            // Ajouter une option par défaut
            models.Insert(0, new SelectListItem
                {
                    Value = "0",
                    Text = "Miata"
                });
            models.Insert(1, new SelectListItem
                {
                    Value = "1",
                    Text = "Liberty"
                });

                return models;
            }
            public async Task<Modele> GetModele(int id)
            {
                var modele = await _context.Modeles.SingleOrDefaultAsync(m => m.Id == id);
                return modele;
            }

            public async Task<IList<Modele>> GetModel()
            {
                var modele = await _context.Modeles.ToListAsync();
                return modele;
            }
            /// <summary>
            /// Get all brands from the inventory
            /// </summary>
            public IEnumerable<Modele> GetAllModels()
            {
                IEnumerable<Modele> ModelEntities = _context.Modeles.Where(p => p.Id > 0);
                return ModelEntities.ToList();
            }

            public void SaveModel(Modele modele)
            {
                if (modele != null)
                {

                    _context.Modeles.Add(modele);
                    _context.SaveChanges();
                }
            }

            public void DeleteModel(int id)
            {
            Modele modele = _context.Modeles.First(p => p.Id == id);
                if (modele != null)
                {
                    _context.Modeles.Remove(modele);
                    _context.SaveChanges();
                }
            }
        }

    }
