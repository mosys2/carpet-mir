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
        public string? Caption { get; set; }
        public string? Writer { get; set; }
        public DateTime ShowAt { get; set; }=DateTime.Now;
        public string[] CategoryBlog  { get; set; }
        public string[]? BlogTags { get; set; }
        public bool IsActive { get; set; }
        public bool ShowWriter { get; set; }
        public string LanguegeId { get; set; }
        public string Image { get; set; }
    }
}
