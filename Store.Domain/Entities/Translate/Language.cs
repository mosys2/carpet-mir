using Store.Domain.Entities.Blogs;
using Store.Domain.Entities.Commons;
using Store.Domain.Entities.HomePages;
using Store.Domain.Entities.Products;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Translate
{
    public class Language:BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Slider> Sliders { get; set; }
        public ICollection<Product> Products { get; set; }
		public ICollection<Comment> Comments { get; set; }
		public ICollection<Category> Categories { get; set; }
		public ICollection<UserAddress> UserAddresses { get; set; }
		public ICollection<Brand> Brands { get; set; }
		public ICollection<Feature> Features { get; set; }
		public ICollection<Tag> Tags { get; set; }
		public ICollection<Blog> Blogs { get; set; }
		public ICollection<CommentBlog> CommentBlogs { get; set; }
		public ICollection<CategoryBlog> CategoryBlogs { get; set; }
        public ICollection<BlogTag> BlogTags { get; set; }







    }
}
