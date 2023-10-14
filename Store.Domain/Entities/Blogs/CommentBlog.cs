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
	public class CommentBlog:BaseEntity
	{
		public virtual CommentBlog ParentComment { get; set; }
		public string? ParentCommentId { get; set; }
		public string? Content { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public bool Approved { get; set; }
		public bool Seen { get; set; }
		public virtual Blog Blog { get; set; }
		public string BlogId { get; set; }
        public DateTime? Sort { get; set; }
        public virtual Language Language { get; set; }
		public string LanguageId { get; set; }

        public virtual ICollection<Comment> SubComments { get; set; }
	}
}
