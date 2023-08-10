using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Products.Commands.AddNewBrand;
using Store.Application.Services.Products.Commands.AddNewFeatureToCategory;
using Store.Application.Services.Products.Commands.DeleteBrand;
using Store.Application.Services.Products.Queries.GetAllCategoryFeature;
using Store.Application.Services.ProductsSite.Commands.AddNewCategory;
using Store.Application.Services.ProductsSite.Commands.AddNewProduct;
using Store.Application.Services.ProductsSite.Commands.AddNewTag;
using Store.Application.Services.ProductsSite.Commands.DeleteCategory;
using Store.Application.Services.ProductsSite.Commands.DeleteProducts;
using Store.Application.Services.ProductsSite.Commands.EditProducts;
using Store.Application.Services.ProductsSite.Queries.GetBrandsList;
using Store.Application.Services.ProductsSite.Queries.GetCategory;
using Store.Application.Services.ProductsSite.Queries.GetEditProductsList;
using Store.Application.Services.ProductsSite.Queries.GetParentCategory;
using Store.Application.Services.ProductsSite.Queries.GetProductsList;
using Store.Application.Services.ProductsSite.Queries.GetTagsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.FacadPattern
{
	public class ProductFacad : IProductFacad
	{
		private readonly IDatabaseContext _context;
		private readonly IConfiguration _configuration;
        private readonly IGetSelectedLanguageServices _language;


        public ProductFacad(IDatabaseContext context, IConfiguration configuration, IGetSelectedLanguageServices language)
		{
			_context = context;
			_configuration = configuration;
			_language= language;	
		}
		private AddCategoryService _addCategoryService;
		private IGetCategory _getCategory;
		private IGetParentCategory _getParentCategory;
		private IDeleteCategory _deleteCategory;
		private IGetBrandListService _getBrandListService;
		private IAddTagService _addTagService;
		private IGetTagsListService _getTagsListService;
		private IAddProductService _addProductService;
		private IGetProductsListService _getProductsListService;
		private IRemoveProductService _removeProductService;
		private IGetEditProductListService _getEditProductListService;
		private IEditProductsService _getEditProductsService;
		private IAddNewBrandService _addNewBrandService;
		private IRemoveBrandService _removeBrandService;
		private IAddNewFeatureToCategoryService _addNewFeatureToCategoryService;
		private IGetAllCategoryFeatureService _getAllCategoryFeatureService;
		//Add Category
		public AddCategoryService AddCategoryService
		{
			get { return _addCategoryService = _addCategoryService ?? new AddCategoryService(_context,_language); }

		}
		//GetCategory
		public IGetCategory GetCategory
		{
			get
			{
				return _getCategory = _getCategory ?? new GetCategoryService(_context);
			}
		}
		//GetParrenCategory
		public IGetParentCategory GetParentCategory
		{
			get
			{
				return _getParentCategory = _getParentCategory ?? new GetParentCategory(_context,_language,_configuration);
			}
		}
		//DeleteCategory
		public IDeleteCategory GetDeleteCategory
		{
			get
			{
				return _deleteCategory = _deleteCategory ?? new DeleteCategoryService(_context);
			}
		}
		//GetBrands
		public IGetBrandListService GetBrandListService
		{
			get
			{
				return _getBrandListService = _getBrandListService ?? new GetBrandListService(_context, _configuration, _language);
			}
		}
		//AddTag
		public IAddTagService AddTagService
		{
			get
			{
				return _addTagService = _addTagService ?? new AddTagService(_context,_language);
			}
		}
		//Get List Tags
		public IGetTagsListService GetTagsListService
		{
			get
			{
				return _getTagsListService = _getTagsListService ?? new GetTagsListService(_context, _language);
			}
		}
		//Add Product
		public IAddProductService AddProductService
		{
			get
			{
				return _addProductService = _addProductService ?? new AddProductService(_context,_language);
			}
		}
		//GetProducts List
		public IGetProductsListService GetProductsListService
		{
			get
			{
				return _getProductsListService = _getProductsListService ?? new GetProductsListService(_context, _configuration,_language);
			}
		}
		//Remove Product
		public IRemoveProductService RemoveProductService
		{
			get
			{
				return _removeProductService = _removeProductService ?? new RemoveProductService(_context);
			}

		}
		//Get Edit Product
		public IGetEditProductListService GetEditProductListService
		{
			get
			{
				return _getEditProductListService = _getEditProductListService ?? new GetEditProductListService(_context, _configuration);
			}
		}

		public IEditProductsService EditProductsService
		{
			get
			{
				return _getEditProductsService = _getEditProductsService ?? new EditProductsService(_context);
			}
		}

        public IAddNewBrandService AddNewBrandService
		{
            get
            {
                return _addNewBrandService = _addNewBrandService ?? new AddNewBrandService(_context,_language);
            }
        }

        public IRemoveBrandService RemoveBrandService
		{
            get
            {
                return _removeBrandService = _removeBrandService ?? new RemoveBrandService(_context);
            }
        }

        public IAddNewFeatureToCategoryService AddNewFeatureToCategoryService
		{
            get
            {
                return _addNewFeatureToCategoryService = _addNewFeatureToCategoryService ?? new AddNewFeatureToCategoryService(_context,_language);
            }
        }

        public IGetAllCategoryFeatureService GetAllCategoryFeatureService
		{
            get
            {
                return _getAllCategoryFeatureService = _getAllCategoryFeatureService ?? new GetAllCategoryFeatureService(_context, _language);
            }
        }
    }
}
