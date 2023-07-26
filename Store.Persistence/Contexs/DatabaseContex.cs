using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Constant.Language;
using Store.Common.Constant.Roles;
using Store.Domain.Entities.Abouts;
using Store.Domain.Entities.Authors;
using Store.Domain.Entities.Blogs;
using Store.Domain.Entities.Carts;
using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Contacts;
using Store.Domain.Entities.Finances;
using Store.Domain.Entities.HomePages;
using Store.Domain.Entities.Medias;
using Store.Domain.Entities.Orders;
using Store.Domain.Entities.Pages;
using Store.Domain.Entities.Post;
using Store.Domain.Entities.Products;
using Store.Domain.Entities.Results;
using Store.Domain.Entities.Settings;
using Store.Domain.Entities.Translate;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Contexs
{
    public class DatabaseContex : IdentityDbContext<User, Role, string>, IDatabaseContext
    {

        public DatabaseContex(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> ContactType { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Media> Medias { get; set; }
		public DbSet<Brand> Brands { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Feature> Features { get; set; }
		public DbSet<ItemTag> ItemTags { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Rate> Rates { get; set; }
		public DbSet<Tag> Tags { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<RequestPay> RequestPays { get; set; }
        public DbSet<Slider> Sliders { get; set ;}
        public DbSet<Result> Results { get; set; }
        public DbSet<Language> Languages { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<CommentBlog> CommentBlogs { get; set; }
		public DbSet<CategoryBlog> CategoryBlogs { get; set; }
        public DbSet<ItemCategoryBlog> ItemCategoryBlogs { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<BlogItemTag> BlogItemTags { get; set; }
		public DbSet<Author> Authors { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SiteContact> SiteContacts { get; set; }
        public DbSet<SiteContactType> SiteContactTypes { get; set; }
        public DbSet<PageCreator> PageCreators { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PageCreator>(b =>
            {
                b.HasOne(p => p.Language)
                .WithMany(p => p.PageCreators)
                .OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<ContactUs>(b =>
            {
                b.HasOne(p => p.Language)
                .WithMany(p => p.ContactUs)
                .OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<SiteContact>(b =>
            {
                b.HasOne(p => p.Language)
                .WithMany(p => p.SiteContacts)
                .OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<About>(b =>
            {
                b.HasOne(p => p.Language)
                .WithMany(p => p.Abouts)
                .OnDelete(DeleteBehavior.NoAction);
            });
            builder.Entity<Product>(b =>
            {
               b.HasOne(p => p.Language)
               .WithMany(p => p.Products)
               .OnDelete(DeleteBehavior.NoAction);
            });
			builder.Entity<Comment>(b =>
			{
				b.HasOne(p => p.Language)
				.WithMany(p => p.Comments)
				.OnDelete(DeleteBehavior.NoAction);
			});
			builder.Entity<Category>(b =>
			{
				b.HasOne(p => p.Language)
				.WithMany(p => p.Categories)
				.OnDelete(DeleteBehavior.NoAction);
			});
			builder.Entity<Brand>(b =>
			{
				b.HasOne(p => p.Language)
				.WithMany(p => p.Brands)
				.OnDelete(DeleteBehavior.NoAction);
			});
			builder.Entity<Tag>(b =>
			{
				b.HasOne(p => p.Language)
				.WithMany(p => p.Tags)
				.OnDelete(DeleteBehavior.NoAction);
			});
			builder.Entity<UserAddress>(b =>
			{
				b.HasOne(p => p.Language)
				.WithMany(p => p.UserAddresses)
				.OnDelete(DeleteBehavior.NoAction);
			});
			builder.Entity<Blog>(b =>
			{
				b.HasOne(p => p.Language)
				.WithMany(p => p.Blogs)
				.OnDelete(DeleteBehavior.NoAction);
			});
			builder.Entity<CommentBlog>(b =>
			{
				b.HasOne(p => p.Language)
				.WithMany(p => p.CommentBlogs)
				.OnDelete(DeleteBehavior.NoAction);
			});
			builder.Entity<CategoryBlog>(b =>
			{
				b.HasOne(p => p.Language)
				.WithMany(p => p.CategoryBlogs)
				.OnDelete(DeleteBehavior.NoAction);
			});
            builder.Entity<BlogTag>(b =>
            {
                b.HasOne(p => p.Language)
                .WithMany(p => p.BlogTags)
                .OnDelete(DeleteBehavior.NoAction);
            });
			builder.Entity<Author>(b =>
			{
				b.HasOne(p => p.Language)
				.WithMany(p => p.Authors)
				.OnDelete(DeleteBehavior.NoAction);
			});
			builder.Entity<Order>(b =>
            {
                b.HasOne(p => p.User)
               .WithMany(p => p.Orders)
               .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(p => p.RequestPay)
                .WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Rate>()
                .HasOne(r => r.User)
                .WithMany(u => u.Rates)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);
			
			builder.Entity<User>(b =>
            {
                // Primary key
                b.HasKey(u => u.Id);

                // Indexes for "normalized" username and email, to allow efficient lookups
                b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
                b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");
                b.HasQueryFilter(p => !p.IsRemoved);
                // Maps to the AspNetUsers table
                b.ToTable("Users");

                // A concurrency token for use with the optimistic concurrency checking
                b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

                // Limit the size of columns to use efficient database types
                b.Property(u => u.UserName).HasMaxLength(256);
                b.Property(u => u.NormalizedUserName).HasMaxLength(256);
                b.Property(u => u.Email).HasMaxLength(256);
                b.Property(u => u.NormalizedEmail).HasMaxLength(256);
               

                // The relationships between User and other entity types
                // Note that these relationships are configured with no navigation properties

                // Each User can have many UserClaims
                b.HasMany<IdentityUserClaim<string>>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

                // Each User can have many UserLogins
                b.HasMany<IdentityUserLogin<string>>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

                // Each User can have many UserTokens
                b.HasMany<IdentityUserToken<string>>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany<IdentityUserRole<string>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            });
            builder.Entity<IdentityUserClaim<string>>(b =>
            {
                // Primary key
                b.HasKey(uc => uc.Id);

                // Maps to the AspNetUserClaims table
                b.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(b =>
            {
                // Composite primary key consisting of the LoginProvider and the key to use
                // with that provider
                b.HasKey(l => new { l.LoginProvider, l.ProviderKey });

                // Limit the size of the composite key columns due to common DB restrictions
                b.Property(l => l.LoginProvider).HasMaxLength(128);
                b.Property(l => l.ProviderKey).HasMaxLength(128);

                // Maps to the AspNetUserLogins table
                b.ToTable("UserLogins");
            });

            builder.Entity<IdentityUserToken<string>>(b =>
            {
                // Composite primary key consisting of the UserId, LoginProvider and Name
                b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

                // Limit the size of the composite key columns due to common DB restrictions

                // Maps to the AspNetUserTokens table
                b.ToTable("UserTokens");
            });

            builder.Entity<IdentityRole<string>>(b =>
            {
                // Primary key
                b.HasKey(r => r.Id);

                // Index for "normalized" role name to allow efficient lookups
                b.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

                // Maps to the AspNetRoles table
                b.ToTable("Roles");

                // A concurrency token for use with the optimistic concurrency checking
                b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

                // Limit the size of columns to use efficient database types
                b.Property(u => u.Name).HasMaxLength(256);
                b.Property(u => u.NormalizedName).HasMaxLength(256);


                // The relationships between Role and other entity types
                // Note that these relationships are configured with no navigation properties

                // Each Role can have many entries in the UserRole join table
                b.HasMany<IdentityUserRole<string>>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany<IdentityRoleClaim<string>>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            });

            builder.Entity<IdentityRoleClaim<string>>(b =>
            {
                // Primary key
                b.HasKey(rc => rc.Id);

                // Maps to the AspNetRoleClaims table
                b.ToTable("RoleClaims");
            });

            builder.Entity<IdentityUserRole<string>>(b =>
            {
                // Primary key
                b.HasKey(r => new { r.UserId, r.RoleId });

                // Maps to the AspNetUserRoles table
                b.ToTable("UserRoles");
            });
            //Seed Data
            SeedData(builder);

            //-- عدم نمایش اطلاعات حذف شده
            ApplyQueryFilter(builder);

        }
        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            //modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Cart>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<CartItem>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserAddress>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Brand>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Slider>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Result>().HasQueryFilter(p => !p.IsRemoved);
			modelBuilder.Entity<Blog>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<About>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ContactUs>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<PageCreator>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<SiteContact>().HasQueryFilter(p => !p.IsRemoved);

        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Name = UserRolesName.Admin, PersianTitle = UserRoleTitle.Admin, NormalizedName = "ADMIN" });
            modelBuilder.Entity<Role>().HasData(new Role { Name = UserRolesName.Operator, PersianTitle = UserRoleTitle.Operator, NormalizedName = "OPERATOR" });
            modelBuilder.Entity<Role>().HasData(new Role { Name = UserRolesName.Customer, PersianTitle = UserRoleTitle.Customer, NormalizedName = "CUSTOMER" });

            //Add Language
            string Guid_En = Guid.NewGuid().ToString();
            string Guid_Ar = Guid.NewGuid().ToString();
            string Guid_Ru = Guid.NewGuid().ToString();

            modelBuilder.Entity<Language>().HasData(new Language { Id = Guid_Ru, Name = LanguageConst.Ru,Culture="ru-RU" });
            modelBuilder.Entity<Language>().HasData(new Language { Id = Guid_Ar, Name =LanguageConst.Ar , Culture = "ar-SA" });
			modelBuilder.Entity<Language>().HasData(new Language { Id = Guid_En, Name = LanguageConst.En, Culture = "en-US" });

            //Add Setting by languageId
            modelBuilder.Entity<Setting>().HasData(new Setting { Id=Guid.NewGuid().ToString(), LanguageId = Guid_Ru });
            modelBuilder.Entity<Setting>().HasData(new Setting { Id=Guid.NewGuid().ToString(), LanguageId = Guid_Ar });
            modelBuilder.Entity<Setting>().HasData(new Setting { Id=Guid.NewGuid().ToString(), LanguageId = Guid_En });

            //Add SitContactType by languageId 
            modelBuilder.Entity<SiteContactType>().HasData(new SiteContactType { Id = Guid.NewGuid().ToString(), LanguageId=Guid_Ru, Title = ContactsTypeRussiaTitle.Mobile, Value = ContactsTypeRussiaValue.Mobile });
            modelBuilder.Entity<SiteContactType>().HasData(new SiteContactType { Id = Guid.NewGuid().ToString(), LanguageId=Guid_Ru, Title = ContactsTypeRussiaTitle.Phone, Value = ContactsTypeRussiaValue.Phone });
            modelBuilder.Entity<SiteContactType>().HasData(new SiteContactType { Id = Guid.NewGuid().ToString(), LanguageId=Guid_Ru, Title = ContactsTypeRussiaTitle.Email, Value = ContactsTypeRussiaValue.Email });
            modelBuilder.Entity<SiteContactType>().HasData(new SiteContactType { Id = Guid.NewGuid().ToString(), LanguageId=Guid_Ru, Title = ContactsTypeRussiaTitle.Address, Value = ContactsTypeRussiaValue.Address });
            modelBuilder.Entity<SiteContactType>().HasData(new SiteContactType { Id = Guid.NewGuid().ToString(), LanguageId=Guid_Ru, Title = ContactsTypeRussiaTitle.SocialMedia, Value = ContactsTypeRussiaValue.SocialMedia });

            modelBuilder.Entity<SiteContactType>().HasData(new SiteContactType { Id = Guid.NewGuid().ToString(), LanguageId=Guid_Ar, Title = ContactsTypeArabicTitle.Mobile, Value = ContactsTypeArabicValue.Mobile });
            modelBuilder.Entity<SiteContactType>().HasData(new SiteContactType { Id = Guid.NewGuid().ToString(), LanguageId=Guid_Ar, Title = ContactsTypeArabicTitle.Phone, Value = ContactsTypeArabicValue.Phone });
            modelBuilder.Entity<SiteContactType>().HasData(new SiteContactType { Id = Guid.NewGuid().ToString(), LanguageId=Guid_Ar, Title = ContactsTypeArabicTitle.Email, Value = ContactsTypeArabicValue.Email });
            modelBuilder.Entity<SiteContactType>().HasData(new SiteContactType { Id = Guid.NewGuid().ToString(), LanguageId=Guid_Ar, Title = ContactsTypeArabicTitle.Address, Value = ContactsTypeArabicValue.Address });
            modelBuilder.Entity<SiteContactType>().HasData(new SiteContactType { Id = Guid.NewGuid().ToString(), LanguageId=Guid_Ar, Title = ContactsTypeArabicTitle.SocialMedia, Value = ContactsTypeArabicValue.SocialMedia });

            modelBuilder.Entity<SiteContactType>().HasData(new SiteContactType { Id = Guid.NewGuid().ToString(), LanguageId=Guid_En, Title = ContactsTypeEnglishTitle.Mobile, Value = ContactsTypeEnglishValue.Mobile });
            modelBuilder.Entity<SiteContactType>().HasData(new SiteContactType { Id = Guid.NewGuid().ToString(), LanguageId=Guid_En, Title = ContactsTypeEnglishTitle.Phone, Value = ContactsTypeEnglishValue.Phone });
            modelBuilder.Entity<SiteContactType>().HasData(new SiteContactType { Id = Guid.NewGuid().ToString(), LanguageId=Guid_En, Title = ContactsTypeEnglishTitle.Email, Value = ContactsTypeEnglishValue.Email });
            modelBuilder.Entity<SiteContactType>().HasData(new SiteContactType { Id = Guid.NewGuid().ToString(), LanguageId=Guid_En, Title = ContactsTypeEnglishTitle.Address, Value = ContactsTypeEnglishValue.Address });
            modelBuilder.Entity<SiteContactType>().HasData(new SiteContactType { Id = Guid.NewGuid().ToString(), LanguageId=Guid_En, Title = ContactsTypeEnglishTitle.SocialMedia, Value = ContactsTypeEnglishValue.SocialMedia });

			//Add About by languageId 
			modelBuilder.Entity<About>().HasData(new Setting { Id = Guid.NewGuid().ToString(), LanguageId = Guid_Ru });
			modelBuilder.Entity<About>().HasData(new Setting { Id = Guid.NewGuid().ToString(), LanguageId = Guid_Ar });
			modelBuilder.Entity<About>().HasData(new Setting { Id = Guid.NewGuid().ToString(), LanguageId = Guid_En });

		}

    }
}
