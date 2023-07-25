using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Authors.Queries.GetAllAuthor;
using Store.Application.Services.Blogs.Commands.AddNewBlog;
using Store.Application.Services.Blogs.Commands.AddNewBlogTag;
using Store.Application.Services.Blogs.Commands.AddNewCategoryBlog;
using Store.Application.Services.Blogs.Commands.EditBlog;
using Store.Application.Services.Blogs.Commands.RemoveBlog;
using Store.Application.Services.Blogs.Commands.RemoveCategoryBlog;
using Store.Application.Services.Blogs.Queries.GetAllBlog;
using Store.Application.Services.Blogs.Queries.GetAllCategoryBlog;
using Store.Application.Services.Blogs.Queries.GetBlogTag;
using Store.Application.Services.Blogs.Queries.GetCategoryBlog;
using Store.Application.Services.Blogs.Queries.GetEditBlog;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.ProductsSite.Queries.GetCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.FacadPattern
{
    public class BlogFacad : IBlogFacad
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IGetSelectedLanguageServices _language;


        public BlogFacad(IDatabaseContext context, IConfiguration configuration, IGetSelectedLanguageServices language)
        {
            _context = context;
            _configuration = configuration;
            _language = language;
        }
        private  IGetAllLanguegeService _getAllLanguegeService;
        private  IGetAllCategoryBlogService _getAllCategoryBlogService;
        private  IGetCategoryBlogService _getCategoryBlogService;
        private  IGetListBlogTagService _getListBlogTagService;
        private  IAddNewBlogTagService _addNewBlogTagService;
        private  IAddNewBlogService _addNewBlogService;
        private  IGetAllAuthorService _getAllAuthorService;
        private  IGetAllBlogService _getAllBlogService;
        private  IGetEditBlogService _getEditBlogService;
        private  IEditBlogService _editBlogService;
        private  IRemoveBlogService _removeBlogService;
        private IRemoveCategoryBlogService _removeCategoryBlogService;
        private IAddNewCategoryBlogService _addNewCategoryBlogService;
        public IGetAllLanguegeService GetAllLanguegeService
        {
            get
            {
                return _getAllLanguegeService = _getAllLanguegeService ?? new GetAllLanguegeService(_context);
            }
        }

        public IGetAllCategoryBlogService GetAllCategoryBlogService
        {
            get
            {
                return _getAllCategoryBlogService = _getAllCategoryBlogService ?? new GetAllCategoryBlogService(_context,_language);
            }
        }
        public IGetCategoryBlogService GetCategoryBlogService
        {
            get
            {
                return _getCategoryBlogService = _getCategoryBlogService ?? new GetCategoryBlogService(_context,_language);
            }
        }
        public IGetListBlogTagService GetListBlogTagService
        {
            get
            {
                return _getListBlogTagService = _getListBlogTagService ?? new GetListBlogTagService(_context, _language);
            }
        }

        public IAddNewBlogTagService AddNewBlogTagService
        {
            get
            {
                return _addNewBlogTagService = _addNewBlogTagService ?? new AddNewBlogTagService(_context, _language);
            }
        }

        public IAddNewBlogService AddNewBlogService
        {
            get
            {
                return _addNewBlogService = _addNewBlogService ?? new AddNewBlogService(_context, _language);
            }
        }

        public IGetAllAuthorService GetAllAuthorService
        {
            get
            {
                return _getAllAuthorService = _getAllAuthorService ?? new GetAllAuthorService(_context, _language);
            }
        }

        public IGetAllBlogService GetAllBlogService
        {
            get
            {
                return _getAllBlogService = _getAllBlogService ?? new GetAllBlogService(_context,_configuration,_language);
            }
        }

        public IGetEditBlogService GetEditBlogService
        {
            get
            {
                return _getEditBlogService = _getEditBlogService ?? new GetEditBlogService(_context);
            }
        }

        public IEditBlogService EditBlogService
        {
            get
            {
                return _editBlogService = _editBlogService ?? new EditBlogService(_context, _language);
            }
        }

        public IRemoveBlogService RemoveBlogService
        {
            get
            {
                return _removeBlogService = _removeBlogService ?? new RemoveBlogService(_context);
            }
        }

        public IRemoveCategoryBlogService RemoveCategoryBlogService
        {
            get
            {
                return _removeCategoryBlogService = _removeCategoryBlogService ?? new RemoveCategoryBlogService(_context);
            }
        }

        public IAddNewCategoryBlogService AddNewCategoryBlogService
        {
            get
            {
                return _addNewCategoryBlogService = _addNewCategoryBlogService ?? new AddNewCategoryBlogService(_context, _language);
            }
        }
    }
}
