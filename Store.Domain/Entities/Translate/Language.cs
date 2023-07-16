using Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Translate
{
    public class Language:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<TextContent> TextContents { get; set; }  
        public ICollection<Translation> Translations { get; set; }
        public string Direction { get; set; }
        public bool IsDefault { get; set; }

    }
}
