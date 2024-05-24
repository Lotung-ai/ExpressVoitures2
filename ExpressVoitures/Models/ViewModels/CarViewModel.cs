using ExpressVoitures.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ExpressVoitures.Models.ViewModels
{
    public class CarViewModel
    {
        
        public int Id { get; set; }

         [Required]
         [Display(Name = "Année :")]
         public int YearId { get; set; }
         public List<SelectListItem>? Years { get; set; }

         [Required]
         [Display(Name = "Marque :")]
         public int BrandId { get; set; }
        public List<SelectListItem>? Brands { get; set; }

         [Required]
         [Display(Name = "Modèle :")]
         public int ModelId { get; set; }
        public List<SelectListItem>? Models { get; set; }

         [Required]
         [Display(Name = "Finition :")]
         public int FinitionId { get; set; }
         public List<SelectListItem>? Finitions { get; set; }

         [Required]
         [DataType(DataType.Date)]
         [Display(Name = "Date d'achat :")]
         public DateTime DateOfPurchase { get; set; }

         [Required]
         [DataType(DataType.Currency)]
         [Display(Name = "Prix d'achat :")]
         public decimal PurchasePrice { get; set; }

         [Display(Name = "Réparations :")]
         public string Repair { get; set; }

         [DataType(DataType.Currency)]
         [Display(Name = "Coût des réparations :")]
         public decimal? RepairPrice { get; set; }

         [DataType(DataType.Date)]
         [Display(Name = "Disponible depuis le ")]
         public DateTime? DateOfAvailabilityForSale { get; set; }

         [DataType(DataType.Currency)]
         [Display(Name = "Prix de vente :")]
         public decimal? SellingPrice { get; set; }

         [DataType(DataType.Date)]
         [Display(Name = "Vendu depuis le")]
         public DateTime? DateOfSale { get; set; }

    }
}
