﻿using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Shapes.Commands.AddNewShape
{
    public class AddNewShapeModel
    {
        public string? Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
