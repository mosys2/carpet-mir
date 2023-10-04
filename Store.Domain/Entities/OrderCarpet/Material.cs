using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Translate;

namespace Store.Domain.Entities.OrderCarpet
{
    public class Material : BaseEntity
    {
        public string? Name { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }

    }

}
