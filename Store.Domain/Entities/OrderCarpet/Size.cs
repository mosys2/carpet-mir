using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Translate;

namespace Store.Domain.Entities.OrderCarpet
{
    public class Size : BaseEntity
    {
        public string? Width { get; set; }
        public string? Height { get; set; }
        public string? Lenght { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }
        public ICollection<ItemSize> ItemSizes { get; set; }

    }

}
