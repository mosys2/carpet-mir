using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Translate;

namespace Store.Domain.Entities.OrderCarpet
{
    public class Size : BaseEntity
    {
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Lenght { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }

    }

}
