﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Constant.Roles;
using Store.Domain.Entities.Carts;
using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Finances;
using Store.Domain.Entities.HomePages;
using Store.Domain.Entities.Medias;
using Store.Domain.Entities.Orders;
using Store.Domain.Entities.Post;
using Store.Domain.Entities.Products;
using Store.Domain.Entities.Results;
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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.Entity<Order>()
               .HasOne(p => p.User)
               .WithMany(p => p.Orders)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Order>()
                .HasOne(p => p.RequestPay)
                .WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            // تنظیم محدودیت کلید خارجی 'FK_Rates_Users_UserId' در جدول 'Rates'
            builder.Entity<Rate>()
                .HasOne(r => r.User)
                .WithMany(u => u.Rates)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);
			builder.Entity<Comment>()
			   .HasOne(r => r.User)
			   .WithMany(u => u.Comments)
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
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Name = UserRolesName.Admin, PersianTitle = UserRoleTitle.Admin, NormalizedName = "ADMIN" });
            modelBuilder.Entity<Role>().HasData(new Role { Name = UserRolesName.Operator, PersianTitle = UserRoleTitle.Operator, NormalizedName = "OPERATOR" });
            modelBuilder.Entity<Role>().HasData(new Role { Name = UserRolesName.Customer, PersianTitle = UserRoleTitle.Customer, NormalizedName = "CUSTOMER" });

            modelBuilder.Entity<ContactType>().HasData(new ContactType { Id = Guid.NewGuid().ToString(), Title = ContactsTypeTitle.Mobail, Value = ContactsTypeValue.Mobail });
            modelBuilder.Entity<ContactType>().HasData(new ContactType { Id = Guid.NewGuid().ToString(), Title = ContactsTypeTitle.Phone, Value = ContactsTypeValue.Phone });
            modelBuilder.Entity<ContactType>().HasData(new ContactType { Id = Guid.NewGuid().ToString(), Title = ContactsTypeTitle.Email, Value = ContactsTypeValue.Email });
            modelBuilder.Entity<ContactType>().HasData(new ContactType { Id = Guid.NewGuid().ToString(), Title = ContactsTypeTitle.Address, Value = ContactsTypeValue.Address });
        }

    }
}
