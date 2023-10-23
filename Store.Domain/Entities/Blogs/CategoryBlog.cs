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
	public class CategoryBlog:BaseEntity
	{
		public string? Name { get; set; }
		public string? Icon { get; set; }
		public string? CssClass { get; set; }
		public bool IsActive { get; set; }
		public string? Description { get; set; }
		public string? Slug { get; set; }
        public DateTime? Sort { get; set; }
        public virtual Language Language { get; set; }
		public string LanguageId { get; set; }

        public ICollection<ItemCategoryBlog> ItemCategoryBlogs { get; set; }

    }
}
