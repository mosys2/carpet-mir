using Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Translate
{
    public class Translation:BaseEntity
    {
        public virtual TextContent TextContent { get; set; }
        public string TextContentId { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }
        public string? TranslateText { get; set; }
    }
}
