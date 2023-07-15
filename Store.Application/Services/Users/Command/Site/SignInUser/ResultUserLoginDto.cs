﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Command.Site.SignInUser
{
	public class ResultUserLoginDto
	{
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string? FullName { get; set; }
        public List<string> Roles { get; set; }
    }
}
