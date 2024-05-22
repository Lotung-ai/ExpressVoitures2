using ExpressVoitures.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpressVoitures.Models.Repositories
{
    public interface IFinitionRepository
    {
        IEnumerable<SelectListItem> GetFinitions();
        Task<Finition> GetFinition(int id);
        Task<IList<Finition>> GetFinition();
        IEnumerable<Finition> GetAllFinitions();

    }
}