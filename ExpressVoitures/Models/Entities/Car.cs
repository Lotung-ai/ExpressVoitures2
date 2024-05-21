namespace ExpressVoitures.Models.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int YearId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int FinitionId { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public decimal PurchasePrice { get; set; }
        public bool Repair { get; set; }
        public decimal? RepairPrice { get; set; }
        public DateTime? DateOfAvailabilityForSale { get; set; }
        public decimal? SellingPrice { get; set; }
        public DateTime? DateOfSale { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Modele Modele { get; set; }
        public virtual Year? Year { get; set; }
        public virtual Finition? Finition { get; set; }


    }
}
