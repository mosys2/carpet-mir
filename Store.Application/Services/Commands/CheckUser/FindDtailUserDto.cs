﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Commands.CheckUser
{
    public class FindDtailUserDto
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
    }
}
