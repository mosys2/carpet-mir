﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Store.Domain.Entities.Abouts;
using Store.Domain.Entities.Authors;
using Store.Domain.Entities.Blogs;
using Store.Domain.Entities.Carts;
using Store.Domain.Entities.Contacts;
using Store.Domain.Entities.Finances;
using Store.Domain.Entities.Galleries;
using Store.Domain.Entities.Groups;
using Store.Domain.Entities.HomePages;
using Store.Domain.Entities.Medias;
using Store.Domain.Entities.Newsletters;
using Store.Domain.Entities.OrderCarpet;
using Store.Domain.Entities.Orders;
using Store.Domain.Entities.Pages;
using Store.Domain.Entities.Post;
using Store.Domain.Entities.Products;
using Store.Domain.Entities.Results;
using Store.Domain.Entities.Settings;
using Store.Domain.Entities.Translate;
using Store.Domain.Entities.Users;
using Store.Domain.Entities.Visits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Store.Domain.Entities.OrderCarpet.Color;
using Size = Store.Domain.Entities.OrderCarpet.Size;

namespace Store.Application.Interfaces.Contexs
{
    public interface IDatabaseContext
    {
        DbSet<Contact> Contacts { get; set; }
        DbSet<ContactType> ContactType { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<Media> Medias { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Feature> Features { get; set; }
        DbSet<ItemTag> ItemTags { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Rate> Rates { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<CartItem> CartItems { get; set; }
        DbSet<Province> Provinces { get; set; }
        DbSet<UserAddress> UserAddresses { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<RequestPay> RequestPays { get; set; }
        DbSet<Slider> Sliders { get; set; }
        DbSet<Result> Results { get; set; }
        DbSet<Language> Languages { get; set; }
	    DbSet<Blog> Blogs { get; set; }
		DbSet<CommentBlog> CommentBlogs { get; set; }
	    DbSet<CategoryBlog> CategoryBlogs { get; set; }
        DbSet<ItemCategoryBlog> ItemCategoryBlogs { get; set; }
        DbSet<BlogTag> BlogTags { get; set; }
        DbSet<BlogItemTag> BlogItemTags { get; set; }
		DbSet<Author> Authors { get; set; }
        DbSet<Setting> Settings { get; set; }
        DbSet<SiteContact> SiteContacts { get; set; }
        DbSet<SiteContactType> SiteContactTypes { get; set; }
        DbSet<PageCreator> PageCreators { get; set; }
        DbSet<About> Abouts { get; set; }
        DbSet<ContactUs> ContactUs { get; set; }
        DbSet<Visit> Visits { get; set; }
        DbSet<VisitData> VisitDatas { get; set; }
        DbSet<RegisterCarpet> RegisterCarpets { get; set; }
        DbSet<Color> Colors { get; set; }
        DbSet<Material> Materials { get; set; }
        DbSet<Size> Sizes { get; set; }
        DbSet<Shape> Shapes { get; set; }
        DbSet<Newsletter> Newsletters { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<GroupItem> GroupItems { get; set; }
        DbSet<Gallery> Galleries { get; set; }
        DbSet<GalleryItem> GalleryItems { get; set; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        void Dispose();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
