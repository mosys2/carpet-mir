using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Authors.Queries.GetAllAuthor;
using Store.Application.Services.Blogs.Commands.AddNewBlog;
using Store.Application.Services.Blogs.Commands.AddNewBlogTag;
using Store.Application.Services.Blogs.Commands.EditBlog;
using Store.Application.Services.Blogs.Commands.RemoveBlog;
using Store.Application.Services.Blogs.Queries.GetAllBlog;
using Store.Application.Services.Blogs.Queries.GetAllCategoryBlog;
using Store.Application.Services.Blogs.Queries.GetBlogTag;
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

        public BlogFacad(IDatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        private  IGetAllLanguegeService _getAllLanguegeService;
        private  IGetAllCategoryBlogService _getAllCategoryBlogService;
        private  IGetListBlogTagService _getListBlogTagService;
        private  IAddNewBlogTagService _addNewBlogTagService;
        private  IAddNewBlogService _addNewBlogService;
        private  IGetAllAuthorService _getAllAuthorService;
        private  IGetAllBlogService _getAllBlogService;
        private  IGetEditBlogService _getEditBlogService;
        private  IEditBlogService _editBlogService;
        private  IRemoveBlogService _removeBlogService;
        public IGetAllLanguegeService GetAllLanguegeService
        {
            get
            {
                return _getAllLanguegeService = _getAllLanguegeService ?? new GetAllLanguegeService(_context);
            }
        }

        public IGetAllCategoryBlogService getAllCategoryBlogService
        {
            get
            {
                return _getAllCategoryBlogService = _getAllCategoryBlogService ?? new GetAllCategoryBlogService(_context);
            }
        }

        public IGetListBlogTagService GetListBlogTagService
        {
            get
            {
                return _getListBlogTagService = _getListBlogTagService ?? new GetListBlogTagService(_context);
            }
        }

        public IAddNewBlogTagService AddNewBlogTagService
        {
            get
            {
                return _addNewBlogTagService = _addNewBlogTagService ?? new AddNewBlogTagService(_context);
            }
        }

        public IAddNewBlogService AddNewBlogService
        {
            get
            {
                return _addNewBlogService = _addNewBlogService ?? new AddNewBlogService(_context);
            }
        }

        public IGetAllAuthorService GetAllAuthorService
        {
            get
            {
                return _getAllAuthorService = _getAllAuthorService ?? new GetAllAuthorService(_context);
            }
        }

        public IGetAllBlogService GetAllBlogService
        {
            get
            {
                return _getAllBlogService = _getAllBlogService ?? new GetAllBlogService(_context,_configuration);
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
                return _editBlogService = _editBlogService ?? new EditBlogService(_context);
            }
        }

        public IRemoveBlogService RemoveBlogService
        {
            get
            {
                return _removeBlogService = _removeBlogService ?? new RemoveBlogService(_context);
            }
        }
    }
}
