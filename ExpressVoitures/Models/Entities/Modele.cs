﻿

namespace ExpressVoitures.Models.Entities
{
    public class Modele
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Car> Cars { get; set; }

    }
}
