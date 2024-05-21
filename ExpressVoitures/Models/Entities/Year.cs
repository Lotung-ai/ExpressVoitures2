

namespace ExpressVoitures.Models.Entities
{
    public class Year
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
