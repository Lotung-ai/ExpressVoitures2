using ExpressVoitures.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpressVoitures.Models.Repositories
{
    public interface IBrandRepository
    {
        List<SelectListItem> GetBrands();
        Task<Brand> GetBrand(int id);
        Task<IList<Brand>> GetBrand();
        IEnumerable<Brand> GetAllBrands();
     
    }
}