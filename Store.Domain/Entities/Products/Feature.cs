using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Products
{
	public class Feature:BaseEntity
	{
		public virtual Product Product { get; set; }
		public string ProductId { get; set; }
		public string DisplayName { get; set; }
        public string? Value { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }
    }
}
