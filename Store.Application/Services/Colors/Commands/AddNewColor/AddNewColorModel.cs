using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Colors.Commands.AddNewColor
{
    public class AddNewColorModel
    {
        public string? Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Value { get; set; }
    }
}
