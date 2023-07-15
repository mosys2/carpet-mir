﻿using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Commands.AddNewCategory
{
    public interface IAddCategory
    {
        Task<ResultDto> Execute(RequestCatgoryDto requestCatgoryDto);
    }
}
