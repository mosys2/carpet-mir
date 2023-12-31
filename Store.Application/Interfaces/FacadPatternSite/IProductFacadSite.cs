﻿using Store.Application.Services.Products.Commands.RegisterCustomCarpet;
using Store.Application.Services.Products.Queries.GetSubCategoryForSite;
using Store.Application.Services.ProductsSite.Queries.GetCategoryForSite;
using Store.Application.Services.ProductsSite.Queries.GetDetailProductModalForSite;
using Store.Application.Services.ProductsSite.Queries.GetDetailProductsForSite;
using Store.Application.Services.ProductsSite.Queries.GetProductsForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces.FacadPatternSite
{
	public interface IProductFacadSite
	{
		IGetProductsForSiteService GetProductsForSiteService {  get; }
		IGetDetailProductSiteService GetDetailProductSiteService { get; }
		IGetProductDetailModalSiteService DetailProductModalSiteService { get; }
		IGetCategorySiteService GetCategorySiteService { get; }
        IRegisterCustomCarpetSiteService RegisterCustomCarpetSiteService { get; }
		IGetSubCategorySiteServie GetSubCategorySiteServie { get; }
    }
}
