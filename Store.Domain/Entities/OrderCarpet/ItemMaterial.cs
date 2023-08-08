using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Products;

namespace Store.Domain.Entities.OrderCarpet
{
    public class ItemMaterial : BaseEntity
    {
        public virtual Material Material { get; set; }
        public string MaterialId { get; set; }
        public virtual Category Category { get; set; }
        public string CategoryId { get; set; }
    }

}
