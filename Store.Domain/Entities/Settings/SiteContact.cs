using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Settings
{
    public class SiteContact:BaseEntity
    {
        public virtual SiteContactType SiteContactType { get; set; }
        public string SiteContactTypeId { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string CssClass { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }

    }
}
