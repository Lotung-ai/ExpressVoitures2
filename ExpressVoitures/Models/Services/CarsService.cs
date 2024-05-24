using ExpressVoitures.Data;
using ExpressVoitures.Models.Entities;
using ExpressVoitures.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoitures.Models.Services
{
    public class CarsService : ICarsService
    {
        public CarsService() { 
        }
        public Car MapToProductEntity(Car carEntity, CarViewModel carViewModel)
        {
            carEntity.YearId = carViewModel.YearId;
            carEntity.BrandId = carViewModel.BrandId;
            carEntity.ModelId = carViewModel.ModelId;
            carEntity.FinitionId = carViewModel.FinitionId;
            carEntity.DateOfPurchase = carViewModel.DateOfPurchase;
            carEntity.PurchasePrice = carViewModel.PurchasePrice;
            carEntity.Repair = carViewModel.Repair;
            carEntity.RepairPrice = carViewModel.RepairPrice;
            carEntity.DateOfAvailabilityForSale = carViewModel.DateOfAvailabilityForSale;
            carEntity.SellingPrice = carViewModel.SellingPrice;
            carEntity.DateOfSale = carViewModel.DateOfSale;

            return carEntity;
        }
        public CarViewModel MapToCarViewModel(Car car)
        {
            CarViewModel carViewModel = new CarViewModel
            {

                YearId = car.YearId,
                BrandId = car.BrandId,
                ModelId = car.ModelId,
                FinitionId = car.FinitionId,
                DateOfPurchase = car.DateOfPurchase,
                PurchasePrice = car.PurchasePrice,
                Repair = car.Repair,
                RepairPrice = car.RepairPrice,
                DateOfAvailabilityForSale = car.DateOfAvailabilityForSale,
                SellingPrice = car.SellingPrice,
                DateOfSale = car.DateOfSale
            };
            return carViewModel;
        }

    }
}
