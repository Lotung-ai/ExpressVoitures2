using ExpressVoitures.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpressVoitures.Models.Repositories
{
    public interface IYearRepository
    {
        IEnumerable<SelectListItem> GetYears();
        Task<Year> GetYear(int id);
        Task<IList<Year>> GetYear();
        IEnumerable<Year> GetAllYears();
    }
}