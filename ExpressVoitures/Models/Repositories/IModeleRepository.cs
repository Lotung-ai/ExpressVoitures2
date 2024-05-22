using ExpressVoitures.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpressVoitures.Models.Repositories
{
    public interface IModeleRepository
    {
        IEnumerable<SelectListItem> GetModels();
        Task<Modele> GetModele(int id);
        Task<IList<Modele>> GetModel();
        IEnumerable<Modele> GetAllModels();
    }
}