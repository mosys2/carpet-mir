﻿using Store.Domain.Entities.Commons;
using Store.Domain.Entities.OrderCarpet;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Products
{
    public class Category : BaseEntity
    {
        public virtual Category ParentCategory { get; set; }
        public string? ParentCategoryId { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public string? CssClass { get; set; }
        public bool IsActive { get; set; } = true;
        public string? Description { get; set; }
        public string? Slug { get; set; }
        public DateTime? Sort { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }
        public ICollection<Product> Products { get; set; }
		//برای نمایش زیر دسته های هر گروه
		public virtual ICollection<Category> SubCategories { get; set; }


    }
}
