using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Common
{
    public static class Pagination
    {
        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source, int page, int pageSize, out int rowsCount)
        {
            rowsCount = source.Count();
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static string PaginateSite(int pageNumber, int itemsPerPage, int total, string pageName, string searchString = "", string tag = "", string category = "", string subcategory = "")
        {
            StringBuilder result = new StringBuilder();
            string searchAndTagUrl = string.Empty;
            int totalItems = total;
            if (!string.IsNullOrEmpty(searchString.Trim()))
            {
                searchAndTagUrl += "&searchkey=" + searchString.Trim().Replace(' ', '-');
            }
            if (!string.IsNullOrEmpty(tag))
            {
                searchAndTagUrl += "&tag=" + tag.Replace(' ', '-');
            }
            if (!string.IsNullOrEmpty(category))
            {
                searchAndTagUrl += "&category=" + category.Replace(' ', '-');
            }
            if (!string.IsNullOrEmpty(subcategory))
            {
                searchAndTagUrl += "&subcategory=" + subcategory.Replace(' ', '-');
            }
            if (totalItems > itemsPerPage)
            {
                result.Append($@"<div class=""text-center margin-100px-top md-margin-50px-top wow animate__fadeInUp"">
                        <div class=""pagination text-small text-uppercase text-extra-dark-gray"">
                            <ul class=""mx-auto"">");
                int totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);

                const int visiblePageCount = 5;

                int startPage = Math.Max(1, pageNumber - (visiblePageCount / 2));
                int endPage = Math.Min(totalPages, startPage + visiblePageCount - 1);

                if (pageNumber > 1)
                {
                    result.Append($@"<li><a href=""/{pageName}?page={pageNumber - 1}{searchAndTagUrl}""><i class=""fas fa-long-arrow-alt-left margin-5px-right d-none d-md-inline-block""></i> Prev</a></li>");
                }
                else
                {
                    result.Append($@"<li ><a href=""#""><i class=""fas fa-long-arrow-alt-left margin-5px-right d-none d-md-inline-block""></i> Prev</a></li>");
                }

                if (startPage > 1)
                {
                    result.Append($@"<li><a href=""/{pageName}?page=1{searchAndTagUrl}"">1</a></li>");
                    if (startPage > 2)
                    {
                        result.Append($@"<li><a href=""javascript:void(0)"">...</a></li>");
                    }
                }

                for (int i = startPage; i <= endPage; i++)
                {
                    if (i == pageNumber)
                    {
                        result.Append($@"<li class=""active""><a href=""#"">{i}</a></li>");
                    }
                    else
                    {
                        result.Append($@"<li><a href=""/{pageName}?page={i}{searchAndTagUrl}"">{i}</a></li>");
                    }
                }

                if (endPage < totalPages)
                {
                    if (endPage < totalPages - 1)
                    {
                        result.Append($@"<li><a href=""javascript:void(0)"">...</a></li>");
                    }
                    result.Append($@"<li><a href=""/{pageName}?page={totalPages}{searchAndTagUrl}"">{totalPages}</a></li>");
                }

                if (pageNumber < totalPages)
                {
                    result.Append($@"<li><a href=""/{pageName}?page={pageNumber + 1}{searchAndTagUrl}"">Next <i class=""fas fa-long-arrow-alt-right margin-5px-left d-none d-md-inline-block""></i></a></li>");
                }
                else
                {
                    result.Append($@"<li ><a href=""#"">Next <i class=""fas fa-long-arrow-alt-right margin-5px-left d-none d-md-inline-block""></i></a></li>");
                }

                result.Append($@"</ul>
                        </div>
                    </div>");
            }
            return result.ToString();
        }
        public static string PaginateAdmin(int pageNumber, int itemsPerPage, int total, string pageName, string searchString = null, string tag = null, string category = null)
        {
            StringBuilder result = new StringBuilder();
            string searchAndTagUrl = string.Empty;
            int totalItems = total;
            if (!string.IsNullOrEmpty(searchString))
            {
                searchAndTagUrl = "&searchkey=" + searchString.Trim().Replace(' ', '-');
            }
            if (!string.IsNullOrEmpty(tag))
            {
                searchAndTagUrl = "&tag=" + tag.Replace(' ', '-');
            }
            if (!string.IsNullOrEmpty(category))
            {
                searchAndTagUrl = "&category=" + category.Replace(' ', '-');
            }
            if (totalItems > itemsPerPage)
            {
                result.Append($@"<div class=""intro-y col-span-12 flex flex-wrap sm:flex-row sm:flex-nowrap items-center"">
                                    <ul class=""pagination"">");
                int totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);
                if (pageNumber != 1)
                {
                    result.Append($@"<li>
                    <a class=""pagination__link"" href=""/admin/{pageName}?page={pageNumber - 1}{searchAndTagUrl}""> <svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""1.5"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-chevron-right w-4 h-4""><polyline points=""9 18 15 12 9 6""></polyline></svg></a></li>");
                }
                else
                {
                    result.Append($@"<li>
                    <a class=""pagination__link"" href=""#""><svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""1.5"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-chevron-right w-4 h-4""><polyline points=""9 18 15 12 9 6""></polyline></svg></a> </li>");
                }
                for (int i = 1; i <= totalPages; i++)
                {
                    if (i == pageNumber)
                    {
                        result.Append($@"<li> <a class=""pagination__link pagination__link--active"" href=""#"">{i}</a> </li>");
                    }
                    else
                    {
                        result.Append($@"<li> <a class=""pagination__link"" href=""/admin/{pageName}?page={i}{searchAndTagUrl}"">{i}</a> </li>");
                    }
                }
                if (pageNumber != totalPages)
                {
                    result.Append($@"<li>
                    <a class=""pagination__link"" href=""/admin/{pageName}?page={pageNumber + 1}{searchAndTagUrl}""><svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""1.5"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-chevron-left w-4 h-4""><polyline points=""15 18 9 12 15 6""></polyline></svg> </a></li>");
                }
                else
                {
                    result.Append($@"<li>
                    <a class=""pagination__link"" href=""#""><svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""1.5"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-chevron-left w-4 h-4""><polyline points=""15 18 9 12 15 6""></polyline></svg></a></li>");
                }
                result.Append($@"</ul>
                                </div>");
            }
            return result.ToString();
        }
    }
}
