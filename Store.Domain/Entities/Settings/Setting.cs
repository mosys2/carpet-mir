using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Settings
{
    public class Setting:BaseEntity
    {
        public string? SiteName { get; set; }
        public string? BaseUrl { get; set; }
        public string? Logo { get; set; }
        public string? Logo2 { get; set; }
        public string? Icon { get; set; }
        public int ShowPerPage { get; set; } = 12;
        public string? MetaTags { get; set; }
        public string? Description { get; set; }
        public  string? Menu { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }
    }
}
