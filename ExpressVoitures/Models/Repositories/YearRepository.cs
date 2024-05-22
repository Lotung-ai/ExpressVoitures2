using ExpressVoitures.Data;
using ExpressVoitures.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Models.Repositories
{
    public class YearRepository :IYearRepository
    {
        private readonly ApplicationDbContext _context;

        public YearRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetYears()
        {
            // Récupérer les marques depuis la base de données
            var years = _context.Years
                .Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Value.ToString()
                })
                .ToList();

            // Ajouter une option par défaut
            years.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = "1900"
            });
            years.Insert(1, new SelectListItem
            {
                Value = "1",
                Text = "1901"
            });

            return years;
        }
        public async Task<Year> GetYear(int id)
        {
            var year = await _context.Years.SingleOrDefaultAsync(m => m.Id == id);
            return year;
        }

        public async Task<IList<Year>> GetYear()
        {
            var year = await _context.Years.ToListAsync();
            return year;
        }
        /// <summary>
        /// Get all Years from the inventory
        /// </summary>
        public IEnumerable<Year> GetAllYears()
        {
            IEnumerable<Year> YearsEntities = _context.Years.Where(p => p.Id > 0);
            return YearsEntities.ToList();
        }

        public void SaveYear(Year year)
        {
            if (year != null)
            {

                _context.Years.Add(year);
                _context.SaveChanges();
            }
        }

        public void DeleteYear(int id)
        {
            Year year = _context.Years.First(p => p.Id == id);
            if (year != null)
            {
                _context.Years.Remove(year);
                _context.SaveChanges();
            }
        }
    }
}
