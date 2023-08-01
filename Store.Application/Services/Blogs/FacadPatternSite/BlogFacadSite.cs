using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Interfaces.FacadPatternSite;
using Store.Application.Services.Blogs.Commands.AddNewBlogTag;
using Store.Application.Services.Blogs.Commands.AddNewComment;
using Store.Application.Services.Blogs.Queries.GetAllBlogForSite;
using Store.Application.Services.Blogs.Queries.GetCategoryBlogForSite;
using Store.Application.Services.Blogs.Queries.GetDetailBlogForSite;
using Store.Application.Services.Blogs.Queries.GetPopularPostsForSite;
using Store.Application.Services.Blogs.Queries.GetRelatedPostsForSite;
using Store.Application.Services.Blogs.Queries.GetTagBlogForSite;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.ProductsSite.Commands.AddNewCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Blogs.FacadPatternSite
{
    public class BlogFacadSite : IBlogFacadSite
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IGetSelectedLanguageServices _language;


        public BlogFacadSite(IDatabaseContext context, IConfiguration configuration, IGetSelectedLanguageServices language)
        {
            _context = context;
            _configuration = configuration;
            _language = language;
        }


        private IGetAllBlogSiteService _getAllBlogSiteService;
        private IGetCategoryBlogSiteService _getCategoryBlogSiteService;
        private IGetTagBlogSiteService _getTagBlogSiteService;
        private IGetDetailBlogSiteService _getDetailBlogSiteService;
        private IGetRelatedPostsSiteService _getRelatedPostsSiteService;
        private IGetPopularPostsSiteService _getPopularPostsSiteService;
        private IAddCommentBlogService _addCommentBlogService;
        public IGetAllBlogSiteService GetAllBlogSiteService
        {
            get { return _getAllBlogSiteService = _getAllBlogSiteService ?? new GetAllBlogSiteService(_context, _language, _configuration); }
        }

        public IGetCategoryBlogSiteService GetCategoryBlogSiteService
        {
            get { return _getCategoryBlogSiteService = _getCategoryBlogSiteService ?? new GetCategoryBlogSiteService(_context, _language); }
        }

        public IGetTagBlogSiteService GetTagBlogSiteService
        {
            get { return _getTagBlogSiteService = _getTagBlogSiteService ?? new GetTagBlogSiteService(_context, _language); }
        }

        public IGetDetailBlogSiteService GetDetailBlogSiteService
        {
            get { return _getDetailBlogSiteService = _getDetailBlogSiteService ?? new GetDetailBlogSiteService(_context, _language,_configuration); }
        }

        public IGetRelatedPostsSiteService GetRelatedPostsSiteService
        {
            get { return _getRelatedPostsSiteService = _getRelatedPostsSiteService ?? new GetRelatedPostsSiteService(_context, _language, _configuration);}
        }

        public IGetPopularPostsSiteService GetPopularPostsSiteService
        {
            get { return _getPopularPostsSiteService = _getPopularPostsSiteService ?? new GetPopularPostsSiteService(_context, _language, _configuration); }
        }

        public IAddCommentBlogService AddCommentBlogService
        {
            get
            {
                return _addCommentBlogService = _addCommentBlogService ?? new AddCommentBlogService(_context, _language);
            }
        }
    }
}
