using ExpressVoitures.Data;
using ExpressVoitures.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Models.Repositories
{
    public class FinitionRepository :IFinitionRepository
    {

        private readonly ApplicationDbContext _context;

        public FinitionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetFinitions()
        {
            // Récupérer les marques depuis la base de données
            var finitions = _context.Finitions
                .Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Name
                })
                .ToList();

            return finitions;
        }
        public async Task<Finition> GetFinition(int id)
        {
            var finition = await _context.Finitions.SingleOrDefaultAsync(m => m.Id == id);
            return finition;
        }

        public async Task<IList<Finition>> GetFinition()
        {
            var finition = await _context.Finitions.ToListAsync();
            return finition;
        }
        /// <summary>
        /// Get all finitions from the inventory
        /// </summary>
        public IEnumerable<Finition> GetAllFinitions()
        {
            IEnumerable<Finition> FinitionEntities = _context.Finitions.Where(p => p.Id > 0);
            return FinitionEntities.ToList();
        }

        public void SaveModel(Finition finition)
        {
            if (finition != null)
            {

                _context.Finitions.Add(finition);
                _context.SaveChanges();
            }
        }

        public void DeleteFinition(int id)
        {
            Finition finition = _context.Finitions.First(p => p.Id == id);
            if (finition != null)
            {
                _context.Finitions.Remove(finition);
                _context.SaveChanges();
            }
        }
    }
}

