using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.Commands.AddNewBlog
{
    public class AddNewBlogModel
    {
        [Required]
        public string Title { get; set; }
        public string? Content { get; set; }
        public string? Description { get; set; }
		public string? KeyWords { get; set; }
		public string? MetaTag { get; set; }
		public string? Slug { get; set; }
		public DateTime ShowAt { get; set; }=DateTime.Now;
		[Required]
		public string[] CategoryBlog  { get; set; }
        public string[]? BlogTags { get; set; }
		[Required]
		public string AuthorId { get; set; }
        public bool IsActive { get; set; }
        public bool ShowWriter { get; set; }
		
        public string Image { get; set; }
		public string MinPic { get; set; }

	}
}
