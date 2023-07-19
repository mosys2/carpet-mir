using Store.Domain.Entities.Commons;

namespace Store.Domain.Entities.Blogs
{
    public class BlogItemTag:BaseEntity
    {
        public virtual BlogTag BlogTag { get; set; }
        public string BlogTagId { get; set; }
        public virtual Blog Blog { get; set; }
        public string BlogId { get; set; }
    }
}
