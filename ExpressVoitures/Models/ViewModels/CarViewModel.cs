using ExpressVoitures.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.SqlServer.Server;

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
        [Display(Name = "BrandName")]
        public int BrandId { get; set; }
        public List<SelectListItem>? Brands { get; set; }

        [Required]
        [Display(Name = "ModelName")]
        public int ModelId { get; set; }
        public List<SelectListItem>? Models { get; set; }

        [Required]
        [Display(Name = "FinitionName")]
        public int FinitionId { get; set; }
        public List<SelectListItem>? Finitions { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "DateOfPurchase")]
        public DateTime DateOfPurchase { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le format n'est pas bon. ex: 1234.56")]
        [Display(Name = "PurchasePrice")]
        public decimal PurchasePrice { get; set; }

        [Display(Name = "Repair")]
        public string? Repair { get; set; }

        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le format n'est pas bon. ex: 1234.56")]
        [Display(Name = "RepairPrice")]
        public decimal? RepairPrice { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "DateOfAvailabilityForSale")]
        public DateTime? DateOfAvailabilityForSale { get; set; }

        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage ="Le format n'est pas bon. ex: 1234.56")]
        [Display(Name = "SellingPrice")]
        public decimal? SellingPrice { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "DateOfSale")]
        public DateTime? DateOfSale { get; set; }
    }
}
