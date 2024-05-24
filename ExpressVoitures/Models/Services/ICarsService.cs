using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.ViewModels;

namespace ExpressVoitures.Models.Services
{
    public interface ICarsService
    {
        Car MapToProductEntity(Car carEntity, CarViewModel carViewModel);
        CarViewModel MapToCarViewModel(Car car);
    }
}