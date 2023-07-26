﻿using Store.Application.Services.HomePages.Queries.GetSliderForSite;
using Store.Application.Services.ProductsSite.Queries.GetCategoryForSite;
using Store.Application.Services.Results.Queries.GetResultsForSite;

namespace EndPointStore.Models.HomePageViewModel
{
    public class HomePageViewModel
    {
        public List<GetSliderForSiteDto> GetSliderForSites { get; set; }
        public List<CategorySiteDto> CategorySites { get; set; }
        public List<GetResultSiteDto> GetResultSites { get; set; }

    }
}