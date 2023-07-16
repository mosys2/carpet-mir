using Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Translate
{
    public class TextContent:BaseEntity
    {
        public string? OrginalText { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; } 

        public ICollection<Translation> Translations { get; set; }
    }
}
