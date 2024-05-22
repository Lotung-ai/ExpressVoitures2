using ExpressVoitures.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.ViewModels
{
    public class CarViewModel
    {
         public int Id { get; set; }

         [Required]
         [Display(Name = "Year")]
         public int YearId { get; set; }
         public List<SelectListItem>? Years { get; set; }

         [Required]
         [Display(Name = "Brand")]
         public int BrandId { get; set; }
        public List<SelectListItem>? Brands { get; set; }

         [Required]
         [Display(Name = "Model")]
         public int ModelId { get; set; }
        public List<SelectListItem>? Models { get; set; }

         [Required]
         [Display(Name = "Finition")]
         public int FinitionId { get; set; }
         public List<SelectListItem>? Finitions { get; set; }

         [Required]
         [DataType(DataType.Date)]
         [Display(Name = "Date of Purchase")]
         public DateTime DateOfPurchase { get; set; }

         [Required]
         [DataType(DataType.Currency)]
         [Display(Name = "Purchase Price")]
         public decimal PurchasePrice { get; set; }

         [Display(Name = "Requires Repair")]
         public bool Repair { get; set; }

         [DataType(DataType.Currency)]
         [Display(Name = "Repair Price")]
         public decimal? RepairPrice { get; set; }

         [DataType(DataType.Date)]
         [Display(Name = "Date of Availability for Sale")]
         public DateTime? DateOfAvailabilityForSale { get; set; }

         [DataType(DataType.Currency)]
         [Display(Name = "Selling Price")]
         public decimal? SellingPrice { get; set; }

         [DataType(DataType.Date)]
         [Display(Name = "Date of Sale")]
         public DateTime? DateOfSale { get; set; }

       /* public int YearId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int FinitionId { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public decimal PurchasePrice { get; set; }
        public bool Repair { get; set; }
        public decimal RepairPrice { get; set; }
        public DateTime DateOfAvailabilityForSale { get; set; }
        public decimal SellingPrice { get; set; }
        public DateTime DateOfSale { get; set; }

        public SelectList Brands { get; set; }
        public SelectList Finitions { get; set; }
        public SelectList Models { get; set; }
        public SelectList Years { get; set; }*/
    }
}
