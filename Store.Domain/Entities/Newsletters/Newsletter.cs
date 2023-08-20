using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Newsletters
{
    public class Newsletter:BaseEntity
    {
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }
    }
}
