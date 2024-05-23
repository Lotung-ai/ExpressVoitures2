using ExpressVoitures.Data;
using ExpressVoitures.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Models.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;

        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SelectListItem> GetBrands()
        {
            // Récupérer les marques depuis la base de données
            var brands = _context.Brands
                .Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Name
                })
                .ToList();

      

            return brands;
        }
        public async Task<Brand> GetBrand(int id)
        {
            var brand = await _context.Brands.SingleOrDefaultAsync(m => m.Id == id);
            return brand;
        }

        public async Task<IList<Brand>> GetBrand()
        {
            var brand = await _context.Brands.ToListAsync();
            return brand;
        }
        /// <summary>
        /// Get all brands from the inventory
        /// </summary>
        public IEnumerable<Brand> GetAllBrands()
        {
            IEnumerable<Brand> BrandEntities = _context.Brands.Where(p => p.Id > 0);
            return BrandEntities.ToList();
        }

        public void SaveBrand(Brand brand)
        {
            if (brand != null)
            {

                _context.Brands.Add(brand);
                _context.SaveChanges();
            }
        }

        public void DeleteBrand(int id)
        {
            Brand brand = _context.Brands.First(p => p.Id == id);
            if (brand != null)
            {
                _context.Brands.Remove(brand);
                _context.SaveChanges();
            }
        }
    }


}
