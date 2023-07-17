using Store.Domain.Entities.Commons;
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
		public bool IsActive { get; set; } = true;
		public int? Sort { get; set; }
		public string? Description { get; set; }
		public string? Slug { get; set; }
		public virtual Language Language { get; set; }
		public string LanguageId { get; set; }
		public virtual CategoryBlog ParentBlogCategory { get; set; }
		public string? ParentBlogCategoryId { get; set; }
		public virtual ICollection<CategoryBlog> SubBlogCategories { get; set; }
	}
}
