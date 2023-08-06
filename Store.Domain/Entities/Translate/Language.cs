using Store.Domain.Entities.Abouts;
using Store.Domain.Entities.Authors;
using Store.Domain.Entities.Blogs;
using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Contacts;
using Store.Domain.Entities.HomePages;
using Store.Domain.Entities.Pages;
using Store.Domain.Entities.Products;
using Store.Domain.Entities.Settings;
using Store.Domain.Entities.Users;
using Store.Domain.Entities.Visits;
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
        public string Culture { get; set; }
        public ICollection<Slider> Sliders { get; set; }
        public ICollection<Product> Products { get; set; }
		public ICollection<Comment> Comments { get; set; }
		public ICollection<Category> Categories { get; set; }
		public ICollection<UserAddress> UserAddresses { get; set; }
		public ICollection<Brand> Brands { get; set; }
		public ICollection<Tag> Tags { get; set; }
		public ICollection<Blog> Blogs { get; set; }
		public ICollection<CommentBlog> CommentBlogs { get; set; }
		public ICollection<CategoryBlog> CategoryBlogs { get; set; }
        public ICollection<BlogTag> BlogTags { get; set; }
		public ICollection<Author> Authors { get; set; }
        public ICollection<SiteContact> SiteContacts { get; set; }
        public ICollection<SiteContactType> SiteContactTypes { get; set; }
        public ICollection<About> Abouts { get; set; }
        public ICollection<ContactUs> ContactUs { get; set; }
        public ICollection<PageCreator> PageCreators { get; set; }
        public ICollection<Visit> Visits { get; set; }
    }
}
