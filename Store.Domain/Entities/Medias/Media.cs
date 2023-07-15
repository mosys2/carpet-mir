﻿using Store.Common.Constant.FileTypeManager;
using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Products;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Store.Domain.Entities.Medias
{
    public class Media:BaseEntity
    {
        public string? Src { get; set; } 
        public string? Alt { get; set; }
        public string? Description { get; set; }
        public FileTypeEnum MediaType { get; set; }
        public virtual Product Product { get; set; }
		public string ProductId { get; set; }
	}
}
