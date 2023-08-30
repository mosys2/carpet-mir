using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Products;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.OrderCarpet
{
    public class RegisterCarpet:BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public string? Material { get; set; }
        public string? Shape { get; set; }
        public string? CategoryName { get; set; }
        public string? TypeName { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public bool Seen { get; set; }
        public virtual Category Category { get; set; }
        public string? CategoryId { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }
    }
}
