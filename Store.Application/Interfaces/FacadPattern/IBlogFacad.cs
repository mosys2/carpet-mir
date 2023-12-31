﻿using Store.Application.Services.Authors.Queries.GetAllAuthor;
using Store.Application.Services.Blogs.Commands.AddNewBlog;
using Store.Application.Services.Blogs.Commands.AddNewBlogTag;
using Store.Application.Services.Blogs.Commands.AddNewCategoryBlog;
using Store.Application.Services.Blogs.Commands.ChangeStatusComment;
using Store.Application.Services.Blogs.Commands.EditBlog;
using Store.Application.Services.Blogs.Commands.RemoveBlog;
using Store.Application.Services.Blogs.Commands.RemoveCategoryBlog;
using Store.Application.Services.Blogs.Queries.GetAllBlog;
using Store.Application.Services.Blogs.Queries.GetAllCategoryBlog;
using Store.Application.Services.Blogs.Queries.GetAllComments;
using Store.Application.Services.Blogs.Queries.GetBlogTag;
using Store.Application.Services.Blogs.Queries.GetCategoryBlog;
using Store.Application.Services.Blogs.Queries.GetEditBlog;
using Store.Application.Services.Blogs.Queries.GetMoreCommentsBlog;
using Store.Application.Services.Langueges.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces.FacadPattern
{
    public interface IBlogFacad
    {
        IGetAllLanguegeService GetAllLanguegeService {  get; }
        IGetAllCategoryBlogService GetAllCategoryBlogService { get; }
        IGetCategoryBlogService GetCategoryBlogService { get; }
        IGetListBlogTagService GetListBlogTagService { get; }
        IAddNewBlogTagService AddNewBlogTagService { get; }
        IAddNewBlogService AddNewBlogService { get; }
        IGetAllAuthorService GetAllAuthorService { get; }
        IGetAllBlogService GetAllBlogService { get; }
        IGetEditBlogService GetEditBlogService { get; }
        IEditBlogService EditBlogService { get; }
        IRemoveBlogService RemoveBlogService { get; }
        IRemoveCategoryBlogService RemoveCategoryBlogService { get; }
        IAddNewCategoryBlogService AddNewCategoryBlogService { get; }
        IGetAllCommentsService GetAllCommentsService { get; }
        IGetMoreCommentsBlogService GetMoreCommentsBlogService { get; }
        IChangeStatusCommentService ChangeStatusCommentService { get; }
    }
}
