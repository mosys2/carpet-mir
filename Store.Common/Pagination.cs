﻿using System;
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

        public static string PaginateSite(int pageNumber, int itemsPerPage, int total, string pageName, string searchString = null, string tag = null,string category=null)
        {
            StringBuilder result = new StringBuilder();
            string searchAndTagUrl = string.Empty;
            int totalItems = total;
            if (!string.IsNullOrEmpty(searchString.Trim()))
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
                result.Append($@"<div class="" text-center margin-100px-top md-margin-50px-top wow animate__fadeInUp"">
                                <div class=""pagination text-small text-uppercase text-extra-dark-gray"">
                                    <ul class=""mx-auto"">");
                int totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);
                if (pageNumber != 1)
                {
                    result.Append($@"<li><a href=""/{pageName}?page={pageNumber - 1}{searchAndTagUrl}""><i class=""fas fa-long-arrow-alt-left margin-5px-right d-none d-md-inline-block""></i> Prev</a></li>");
                }
                else
                {
                    result.Append($@"<li ><a href=""#""><i class=""fas fa-long-arrow-alt-left margin-5px-right d-none d-md-inline-block""></i> Prev</a></li>");
                }
                for (int i = 1; i <= totalPages; i++)
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
                if (pageNumber != totalPages)
                {
                    result.Append($@"<li><a href=""/{pageName}?page={pageNumber+1}{searchAndTagUrl}"">Next <i class=""fas fa-long-arrow-alt-right margin-5px-left d-none d-md-inline-block""></i></a></li>");
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
    }
}
