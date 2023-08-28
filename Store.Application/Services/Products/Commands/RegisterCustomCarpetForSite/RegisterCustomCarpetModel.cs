using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Commands.RegisterCustomCarpet
{
    public class RegisterCustomCarpetModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime? DeliveryDate { get; set; }
        [Required]
        public string ColorId { get; set; }
        [Required]
        public string SizeId { get; set; }
        [Required]
        public string MaterialId { get; set; }
        [Required]
        public string ShapeId { get; set; }
        [Required]
        public string CategoryId { get; set; }
        public string? TypeName { get; set; }
        public string? ColorCustom { get; set; }
        public string? ShapeCustom { get; set; }
        public string? MaterialCustom { get; set; }


    }
}
