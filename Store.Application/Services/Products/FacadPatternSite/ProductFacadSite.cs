using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Interfaces.FacadPatternSite;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Products.Commands.RegisterCustomCarpet;
using Store.Application.Services.Products.Queries.GetSubCategoryForSite;
using Store.Application.Services.ProductsSite.Queries.GetCategory;
using Store.Application.Services.ProductsSite.Queries.GetCategoryForSite;
using Store.Application.Services.ProductsSite.Queries.GetDetailProductModalForSite;
using Store.Application.Services.ProductsSite.Queries.GetDetailProductsForSite;
using Store.Application.Services.ProductsSite.Queries.GetProductsForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.FacadPatternSite
{
	public class ProductFacadSite:IProductFacadSite
	{
		private readonly IDatabaseContext _context;
		private readonly IConfiguration _configuration;
		private readonly IGetSelectedLanguageServices _languege;

		public ProductFacadSite(IDatabaseContext context,
			IGetSelectedLanguageServices languege,
			IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
			_languege = languege;
		}
		private IGetProductsForSiteService _getProductsForSiteService;
		private IGetDetailProductSiteService _getDetailProductSiteService;
		private IGetProductDetailModalSiteService _getDetailProductModalSiteService;
		private IGetCategorySiteService _getCategorySiteService;
		private IRegisterCustomCarpetSiteService _registerCustomCarpetService;
		private IGetSubCategorySiteServie _getSubCategorySiteServie;
		//Get Products For Site
		public IGetProductsForSiteService GetProductsForSiteService
		{
			get
			{
				return _getProductsForSiteService = _getProductsForSiteService ?? new GetProductsForSiteService(_context,_configuration,_languege);
			}
		}
        //Get Detail Product Site
        public IGetDetailProductSiteService GetDetailProductSiteService
		{
            get
            {
                return _getDetailProductSiteService = _getDetailProductSiteService ?? new GetDetailProductSiteService(_context,_configuration,_languege);
            }
        }

        public IGetProductDetailModalSiteService DetailProductModalSiteService
		{
            get
            {
                return _getDetailProductModalSiteService = _getDetailProductModalSiteService ?? new GetProductDetailModalSiteService(_context, _configuration);
            }
        }

        public IGetCategorySiteService GetCategorySiteService
		{
            get
            {
				return _getCategorySiteService = _getCategorySiteService ?? new GetCategorySiteService(_context, _languege,_configuration);
            }
        }

        public IRegisterCustomCarpetSiteService RegisterCustomCarpetSiteService
		{
            get
            {
                return _registerCustomCarpetService = _registerCustomCarpetService ?? new RegisterCustomCarpetSiteService(_context, _languege);
            }
        }

        public IGetSubCategorySiteServie GetSubCategorySiteServie
		{
            get
            {
                return _getSubCategorySiteServie = _getSubCategorySiteServie ?? new GetSubCategorySiteServie(_context, _languege);
            }
        }
    }
}
