using DellyShop.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<District> Districts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stars> Stars { get; set; }

        public DbSet<ImageModel> ImageModels { get; set; }

        public DbSet<LastView> LastViews { get; set; }

        public DbSet<MyFavorite> MyFavorites { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<Notifications> Notifications { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.Entity<ProductOrderMany>()
               .HasOne(rt => rt.Order)
               .WithMany(r => r.ProductOrderMany)
               .HasForeignKey(x => x.OrderId);

            builder.Entity<ProductOrderMany>()
               .HasOne(rt => rt.Product)
               .WithMany(r => r.ProductOrderMany)
               .HasForeignKey(x => x.ProductId);

            //builder.Conventions.Remove(&ltOneToManyCascadeDeleteConvention & gt);
            builder.Entity<ImageModel>()
                .HasOne(t => t.Product)
                .WithMany(a => a.ProductImages)
                .IsRequired(false);

            builder.Entity<ImageModel>()
                .HasOne(t => t.Category)
                .WithMany(a => a.Images)
                .IsRequired(false);
            //builder.Entity<ImageModel>()
            //        .HasOne(c => c.Product)
            //        .WithMany(e => e.ProductImages)
            //        .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<ImageModel>()
            //        .HasOne(c => c.Category)
            //        .WithMany(e => e.Images)
            //        .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
