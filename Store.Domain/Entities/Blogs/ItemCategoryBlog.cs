using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Blogs
{
    public class ItemCategoryBlog:BaseEntity
    {
        public virtual Blog Blog { get; set; }
        public string BlogId { get; set; }
        public virtual CategoryBlog CategoryBlog { get; set; }
        public string CategoryBlogId { get; set; }
    }
}
