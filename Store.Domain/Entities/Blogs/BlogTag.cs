using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Products;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Blogs
{
    public class BlogTag:BaseEntity
    {
        public string Name { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }
        public ICollection<BlogItemTag> BlogItemTags { get; set; }
    }
}
