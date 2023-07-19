using Store.Domain.Entities.Blogs;
using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Products;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Authors
{
	public class Author:BaseEntity
	{
        public string Name { get; set; }
        public bool IsActive { get; set; }
		public ICollection<Blog> Blogs { get; set; }
		public virtual Language Language { get; set; }
		public string LanguageId { get; set; }
	}
}
