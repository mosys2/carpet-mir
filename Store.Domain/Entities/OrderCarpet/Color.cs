using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Translate;

namespace Store.Domain.Entities.OrderCarpet
{
    public class Color:BaseEntity
    {
        public string? Name { get; set; }
        public string? Value { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }
        public ICollection<ItemColor> ItemColors { get; set; }

    }

}
