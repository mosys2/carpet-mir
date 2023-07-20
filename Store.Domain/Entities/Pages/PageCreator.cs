﻿using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Pages
{
    public class PageCreator:BaseEntity
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Description { get; set; }
        public string? MetaTag { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }
    }
}
