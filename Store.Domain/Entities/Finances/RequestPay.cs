﻿using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Orders;
using Store.Domain.Entities.Post;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Finances
{
    public class RequestPay : BaseEntity
    {
        public virtual User User { get; set; }
        public string UserId { get; set; }
        public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; } = 0;
        public virtual Province City { get; set; }
        public string? CityId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
