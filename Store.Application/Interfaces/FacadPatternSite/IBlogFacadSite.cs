using Store.Application.Services.Blogs.Queries.GetAllBlogForSite;
using Store.Application.Services.Blogs.Queries.GetCategoryBlogForSite;
using Store.Application.Services.Blogs.Queries.GetDetailBlogForSite;
using Store.Application.Services.Blogs.Queries.GetRelatedPostsForSite;
using Store.Application.Services.Blogs.Queries.GetTagBlogForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces.FacadPatternSite
{
    public interface IBlogFacadSite
    {
        IGetAllBlogSiteService GetAllBlogSiteService { get; }
        IGetCategoryBlogSiteService GetCategoryBlogSiteService { get; }
        IGetTagBlogSiteService GetTagBlogSiteService { get; }
        IGetDetailBlogSiteService GetDetailBlogSiteService { get; }
        IGetRelatedPostsSiteService GetRelatedPostsSiteService { get; }
    }
}
