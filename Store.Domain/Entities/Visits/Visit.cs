﻿using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Visits
{
    public class Visit
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public long Visited { get; set; }
        public DateTime PersianDate { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }

    }
    public class VisitData
    {
        public string Id { get; set; }
        public string? Agent { get; set; }
        public string? Ip { get; set; }
        public DateTime PersianDate { get; set; }
        public DateTime Date { get; set; }
    }
}
