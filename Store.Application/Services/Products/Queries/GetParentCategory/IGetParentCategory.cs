﻿using Store.Common.Dto;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetParentCategory
{
    public interface IGetParentCategory
    {
        Task<List<ParentCategoryDto>> Execute();
    }
}
