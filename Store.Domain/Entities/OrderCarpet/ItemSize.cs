using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Products;

namespace Store.Domain.Entities.OrderCarpet
{
    public class ItemSize : BaseEntity
    {
        public virtual Size Size { get; set; }
        public string SizeId { get; set; }
        public virtual Category Category { get; set; }
        public string CategoryId { get; set; }
    }

}
