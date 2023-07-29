using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Interfaces.FacadPatternSite;
using Store.Application.Services.Blogs.Queries.GetAllBlogForSite;
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
        public IGetAllBlogSiteService GetGetAllBlogSiteService
        {
            get { return _getAllBlogSiteService = _getAllBlogSiteService ?? new GetAllBlogSiteService(_context, _language, _configuration); }
        }
    }
}
