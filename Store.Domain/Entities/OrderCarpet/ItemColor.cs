using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Products;

namespace Store.Domain.Entities.OrderCarpet
{
    public class ItemColor:BaseEntity
    {
        public virtual Color Color { get; set; }
        public string? ColorId { get; set; }
        public virtual Size Size { get; set; }
        public string? SizeId { get; set; }
        public virtual Material Material { get; set; }
        public string? MaterialId { get; set; }
        public virtual Shape Shape { get; set; }
        public string? ShapeId { get; set; }
        public virtual Category Category { get; set; }
        public string CategoryId { get; set; }
    }

}
