using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Products;

namespace Store.Domain.Entities.OrderCarpet
{
    public class ItemColor:BaseEntity
    {
        public virtual Color Color { get; set; }
        public string ColorId { get; set; }
        public virtual Category Category { get; set; }
        public string CategoryId { get; set; }
    }

}
