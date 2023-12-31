﻿using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Results
{
    public class Result:BaseEntity
    {
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string?   Value { get; set; }
        public string? CssClass { get; set; }
        public bool IsActive { get; set; }
        public DateTime? Sort { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }
    }
}
