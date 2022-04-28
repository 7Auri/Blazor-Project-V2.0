using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Product : BaseEntity
    { 
        public string Description { get; set; }
        public int BuyPrice { get; set; }
        public bool IsOfferable { get; set; } = false;
        public bool IsSold { get; set; } = false;
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? ColorId { get; set; }
        public Color Color { get; set; }
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int? StateId { get; set; }
        public State State { get; set; }
        public ProductImage ProductImage { get; set; }

    }
}
