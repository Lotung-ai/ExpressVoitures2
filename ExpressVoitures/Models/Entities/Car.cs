using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Models.Entities
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int YearId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int FinitionId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfPurchase { get; set; }
        public decimal PurchasePrice { get; set; }
        public string? Repair { get; set; }
        public decimal? RepairPrice { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfAvailabilityForSale { get; set; }
        public decimal? SellingPrice { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfSale { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Modele Modele { get; set; }
        public virtual Year? Year { get; set; }
        public virtual Finition? Finition { get; set; }


    }
}
