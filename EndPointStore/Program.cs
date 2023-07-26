using Store.Persistence.Contexs;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Users.Queries.GetUsers;
using Store.Application.Services.Users.Queries.GetRoles;
using Store.Application.Services.Users.Command.RegisterUser;
using Store.Application.Services.Users.Command.DeleteUser;
using Store.Application.Services.Users.Queries.Edit;
using Store.Application.Services.Users.Command.EditUser;
using Store.Application.Services.Commands.CheckUser;
using Store.Application.Services.Commands.CheckEmail;
using Store.Application.Services.Commands;
using Store.Application.Services.Users.Command.Site.SignInUser;
using Microsoft.AspNetCore.Authentication.Cookies;
using Store.Application.Services.Users.Command.Site.SignUpUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Net;
using Store.Domain.Entities.Users;
using Store.Common.Helpers;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection;
using Store.Application.Services.Users.Command.Site.LogOutUser;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.FileManager.Queries.ListDirectory;
using Store.Application.Services.FileManager.Commands.CreateDirectory;
using Store.Application.Services.FileManager.Commands.UploadFiles;
using Store.Application.Services.FileManager.Commands.RemoveFiles;
using Store.Application.Services.ProductsSite.FacadPattern;
using Store.Application.Interfaces.FacadPatternSite;
using Store.Application.Services.ProductsSite.FacadPatternSite;
using Store.Application.Services.ProductsSite.Queries.GetCategoryForSite;
using Store.Application.Services.Carts;
using Store.Application.Services.Posts.Queries;
using Store.Application.Services.UsersAddress.Commands.AddAddressServiceForSite;
using Store.Application.Services.UsersAddress.Queries.GetAddressUserForSite;
using Store.Application.Services.UsersAddress.Queries.GetEditAddressUserForSite;
using Store.Application.Services.UsersAddress.Commands.EditAddressServiceForSite;
using Store.Application.Services.UsersAddress.Commands.RemoveAddressService_ForSite;
using Store.Application.Services.HomePages.Commands.AddNewSlider;
using Store.Application.Services.HomePages.Queries.GetSlider;
using Store.Application.Services.HomePages.Commands.RemoveSlider;
using Store.Application.Services.Results.Commands.AddNewResult;
using Store.Application.Services.Results.Queries.GetResult;
using Store.Application.Services.Results.Commands.RemoveResult;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc;
using EndPointStore.Models;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Blogs.Commands.AddNewBlog;
using Store.Application.Services.Blogs.Commands.AddNewCategoryBlog;
using Store.Application.Services.Blogs.Queries.GetCategoryBlog;
using Store.Application.Services.Blogs.Commands.RemoveCategoryBlog;
using Store.Application.Services.Blogs.Queries.GetAllCategoryBlog;
using Store.Application.Services.Blogs.Commands.AddNewBlogTag;
using Store.Application.Services.Blogs.Queries.GetBlogTag;
using Store.Application.Services.Authors.Commands.AddNewAuthor;
using Store.Application.Services.Authors.Queries.GetAllAuthor;
using Store.Application.Services.Authors.Commands.RemoveAuthor;
using Store.Application.Services.Blogs.Queries.GetAllBlog;
using Store.Application.Services.Blogs.Queries.GetEditBlog;
using Store.Application.Services.Blogs.Commands.EditBlog;
using Store.Application.Services.Blogs.Commands.RemoveBlog;
using Store.Application.Services.Blogs.FacadPattern;
using Store.Application.Services.Abouts.Queries;
using Store.Application.Services.Abouts.Commands;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Localization;
using Store.Application.Services.Langueges;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Localization;
using Store.Application.Services.ContactsUs.Commands.AddNewContactUsForSite;
using Store.Application.Services.ContactsUs.Queries.GetAllContactUs;
using Store.Application.Services.Pages.Queries.GetAllPageCreator;
using Store.Application.Services.Pages.Commands.AddNewPageCreator;
using Store.Application.Services.Pages.Commands.EditPageCreator;
using Store.Application.Services.Pages.Commands.RemovePageCreator;
using Store.Application.Services.Pages.Queries.GetEditPageCreator;
using Store.Application.Services.ContactsUs.Queries.GetShowContactUs;
using Store.Application.Services.ContactsUs.Commands.RemoveContactUs;
using Store.Application.Services.Menu.Queries.IGetMenu;
using Store.Application.Services.SettingsSite.Queries;
using Store.Application.Services.SettingsSite.Commands;
using Store.Application.Services.Menu.Commands.AddNewMenu;
using Store.Application.Services.SiteContacts.Queries.GetContactType;
using Store.Application.Services.SiteContacts.Commands.AddNewSiteContact;
using Store.Application.Services.SiteContacts.Commands.RemoveSiteContact;
using Store.Application.Services.SiteContacts.Queries.GetAllSiteContact;
using Microsoft.AspNetCore.Authentication;
using Store.Application.Helpers;
using Store.Application.Services.HomePages.Queries.GetSliderForSite;
using Store.Application.Services.Results.Queries.GetResultsForSite;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
#region Localization
//Step 1
builder.Services.AddSingleton < LanguageService > ();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization(options => {
    options.DataAnnotationLocalizerProvider = (type, factory) => {
        var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
        return factory.Create("ShareResource", assemblyName.Name);
    };
});
builder.Services.Configure < RequestLocalizationOptions > (options => {
    var supportedCultures = new List < CultureInfo > {
         new CultureInfo("en-US"),
        new CultureInfo("ar-SA"),
        new CultureInfo("ru-RU")
    };
    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
});
#endregion

builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddDbContext<DatabaseContex>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CmsConnectionString")));
builder.Services.AddIdentity<User, Role>(
    options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<DatabaseContex>()
              .AddDefaultTokenProviders().AddRoles<Role>().AddErrorDescriber<CustomIdentityError>();
builder.Services.AddDistributedMemoryCache();
builder.Services.ConfigureApplicationCookie(option =>
{
    // cookie setting
    option.ExpireTimeSpan = TimeSpan.FromMinutes(10);

    //option.LoginPath = "/account/login";
    option.AccessDeniedPath = "/Admin/Account/AccessDenied";
    option.SlidingExpiration = true;
});

//Scopeds
builder.Services.AddScoped<IDatabaseContext, DatabaseContex>();
//Claim Service
builder.Services.AddScoped<IClaimsTransformation, AddClaim>();

builder.Services.AddScoped<IGetUsersServices, GetUsersServices>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveService, RemoveUserService>();
builder.Services.AddScoped<IGetEditUserService, GetEditUserService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();
builder.Services.AddScoped<ICheckUserExitsService, CheckUserService>();
builder.Services.AddScoped<ICheckEmailService, CheckEmailService>();
builder.Services.AddScoped<ICheckMobileExitsService, CheckMobileService>();
builder.Services.AddScoped<ICheckEmailService, CheckEmailService>();
builder.Services.AddScoped<ISignUpUserService, SignUpUserService>();
builder.Services.AddScoped<ISignInUserService, SignInUserService>();
builder.Services.AddScoped<IlogOutUser, LogOutUserService>();
builder.Services.AddScoped<IFileDirectoryService, FileDirectoryServices>();
builder.Services.AddScoped<ICreateDirectory, CreateDirectoryService>();
builder.Services.AddScoped<IUploadFileService, UploadFileService>();
builder.Services.AddScoped<IRemoveFilesOrDirectoriesService, RemoveFilesOrDirectoriesService>();
builder.Services.AddScoped<IProductFacad, ProductFacad>();
builder.Services.AddScoped<IProductFacadSite, ProductFacadSite>();
builder.Services.AddScoped<IGetCategorySiteService, GetCategorySiteService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IGetProvinceServices, GetProvinceServices>();
builder.Services.AddScoped<IGetCityService, GetCityService>();
builder.Services.AddScoped<IGetCityForPayServices, GetCityForPayServices>();
builder.Services.AddScoped<IAddAddressServiceForSite, AddAddressServiceForSite>();
builder.Services.AddScoped<IGetAddressUserForSite, GetAddressUserForSite>();
builder.Services.AddScoped<IGetEditAddressUserForSite, GetEditAddressUserForSite>();
builder.Services.AddScoped<IEditAddressUserForSite, EditAddressUserForSite>();
builder.Services.AddScoped<IRemoveAddressUserForSite, RemoveAddressUserForSite>();
builder.Services.AddScoped<IAddNewSliderService, AddNewSliderService>();
builder.Services.AddScoped<IGetSliderService, GetSliderService>();
builder.Services.AddScoped<IRemoveSliderService, RemoveSliderService>();
builder.Services.AddScoped<IAddNewResultService, AddNewResultService>();
builder.Services.AddScoped<IGetResultService, GetResultService>();
builder.Services.AddScoped<IRemoveResultService, RemoveResultService>();
builder.Services.AddScoped<IGetAllLanguegeService, GetAllLanguegeService>();
builder.Services.AddScoped<IBlogFacad, BlogFacad>();
builder.Services.AddScoped<IGetAboutService, GetAboutService>();
builder.Services.AddScoped<IEditAboutService, EditAboutService>();
builder.Services.AddScoped<IAddNewContactUsServiceForSite, AddNewContactUsServiceForSite>();
builder.Services.AddScoped<IGetAllContactUsService, GetAllContactUsService>();
builder.Services.AddScoped<IGetPageCreatorService, GetPageCreatorService>();
builder.Services.AddScoped<IAddNewPageCreatorService, AddNewPageCreatorService>();
builder.Services.AddScoped<IEditPageCreatorService, EditPageCreatorService>();
builder.Services.AddScoped<IRemovePageCreatorService, RemovePageCreatorService>();
builder.Services.AddScoped<IGetEditPageCreatorService, GetEditPageCreatorService>();
builder.Services.AddScoped<IGetShowContactUsService, GetShowContactUsService>();
builder.Services.AddScoped<IRemoveContactUsService, RemoveContactUsService>();
builder.Services.AddScoped<IGetMenuService, GetMenuService>();
//me
builder.Services.AddScoped<IGetSelectedLanguageServices, GetSelectedLanguageServices>();
builder.Services.AddScoped<IGetSettingServices, GetSettingServices>();
builder.Services.AddScoped<IEditSettingServices,EditSettingServices>();
builder.Services.AddScoped<IAddNewMenuService, AddNewMenuService>();
builder.Services.AddScoped<IGetContactTypeService, GetContactTypeService>();
builder.Services.AddScoped<IGetAllSiteContactService, GetAllSiteContactService>();
builder.Services.AddScoped<IAddNewSiteContactService, AddNewSiteContactService>();
builder.Services.AddScoped<IRemoveSiteContactService, RemoveSiteContactService>();
builder.Services.AddScoped<IGetSliderForSiteService, GetSliderForSiteService>();
builder.Services.AddScoped<IGetResultSiteService, GetResultSiteService>();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
app.UseCookiePolicy();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
         name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.Run();