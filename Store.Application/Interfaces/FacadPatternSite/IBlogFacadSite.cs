using Store.Application.Services.Blogs.Queries.GetAllBlogForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces.FacadPatternSite
{
    public interface IBlogFacadSite
    {
        IGetAllBlogSiteService GetGetAllBlogSiteService { get; }
    }
}
