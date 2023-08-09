using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Sizes.Commands.AddNewSize
{
    public class AddNewSizeModel
    {
        public string? Id { get; set; }
        [Required]
        public int? Width { get; set; }
        [Required]
        public int Lenght { get; set; }
    }
}
