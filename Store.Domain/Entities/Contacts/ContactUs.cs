using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Contacts
{
    public class ContactUs:BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Text { get; set; }
        public bool Seen { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }
    }
}
