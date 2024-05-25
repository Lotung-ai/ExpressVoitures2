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
         [Display(Name = "YearId")]
         public int YearId { get; set; }
         public List<SelectListItem>? Years { get; set; }

         [Required]
         [Display(Name = "BrandId")]
         public int BrandId { get; set; }
        public List<SelectListItem>? Brands { get; set; }

         [Required]
         [Display(Name = "ModelId")]
         public int ModelId { get; set; }
        public List<SelectListItem>? Models { get; set; }

         [Required]
         [Display(Name = "FinitionId")]
         public int FinitionId { get; set; }
         public List<SelectListItem>? Finitions { get; set; }

         [Required]
         [DataType(DataType.Date)]
         [Display(Name = "DateOfPurchase")]
         public DateTime DateOfPurchase { get; set; }

         [Required]
         [DataType(DataType.Currency)]
         [Display(Name = "PurchasePrice")]
         public decimal PurchasePrice { get; set; }

         [Display(Name = "Repair")]
         public string Repair { get; set; }

         [DataType(DataType.Currency)]
         [Display(Name = "RepairPrice")]
         public decimal? RepairPrice { get; set; }

         [DataType(DataType.Date)]
         [Display(Name = "DateOfAvailabilityForSale")]
         public DateTime? DateOfAvailabilityForSale { get; set; }

         [DataType(DataType.Currency)]
         [Display(Name = "SellingPrice")]
         public decimal? SellingPrice { get; set; }

         [DataType(DataType.Date)]
         [Display(Name = "DateOfSale")]
         public DateTime? DateOfSale { get; set; }

    }
}
