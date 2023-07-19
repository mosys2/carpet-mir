using Store.Domain.Entities.Authors;
using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Products;
using Store.Domain.Entities.Translate;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Blogs
{
	public class Blog:BaseEntity
	{
		public string Title { get; set; }
        public int View { get; set; }
		public string? Description { get; set; }
        public string? MetaTag { get; set; }
        public bool State { get; set; }
		public string Content { get; set; }
        public bool WriterShow { get; set; }
        public virtual User User { get; set; }
		public string UserId { get; set; }
		public string? Keywords { get; set; }
        public DateTime ShowAt { get; set; }
        public string? Pic { get; set; }
        public string? MinPic { get; set; }
		public string? Slug { get; set; }
	   public virtual ICollection<CommentBlog> CommentBlogs { get; set; }
        public ICollection<ItemCategoryBlog> ItemCategoryBlogs { get; set; }
        public ICollection<BlogItemTag> BlogItemTags { get; set; }
        public virtual Language Language { get; set; }
		public string LanguageId { get; set; }
		public virtual Author Author { get; set; }
		public string AuthorId { get; set; }


	}
}
