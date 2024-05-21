

namespace ExpressVoitures.Models.Entities
{
    public class Finition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
