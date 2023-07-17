﻿using Store.Domain.Entities.Commons;
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
		public bool State { get; set; }
		public string Text { get; set; }
		public virtual User User { get; set; }
		public string UserId { get; set; }
		public string Key { get; set; }
		public string ImageSrc { get; set; }
		public virtual CategoryBlog CategoryBlog { get; set; }
		public string CategoryBlogId { get; set; }
		public virtual ICollection<CommentBlog> CommentBlogs { get; set; }
		public virtual Language Language { get; set; }
		public string LanguageId { get; set; }
	}
}
