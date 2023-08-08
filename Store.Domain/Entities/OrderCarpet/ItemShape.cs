using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Products;

namespace Store.Domain.Entities.OrderCarpet
{
    public class ItemShape : BaseEntity
    {
        public virtual Shape Shape { get; set; }
        public string ShapeId { get; set; }
        public virtual Category Category { get; set; }
        public string CategoryId { get; set; }
    }

}
