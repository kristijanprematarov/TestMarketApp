namespace TestMarket.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TestMarket.Entities;

    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Product>().HasData(new Product
            //{
            //    ProductId = Guid.NewGuid(),
            //    Name = "Apple Pie",
            //    Price = 12.95M,
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg",
            //    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg",
            //});

            //modelBuilder.Entity<Product>().HasData(new Product
            //{
            //    ProductId = Guid.NewGuid(),
            //    Name = "Blueberry Cheese Cake",
            //    Price = 18.95M,
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrycheesecake.jpg",
            //    ImageThumbnailUrl =
            //        "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrycheesecakesmall.jpg",
            //});

            //modelBuilder.Entity<Product>().HasData(new Product
            //{
            //    ProductId = Guid.NewGuid(),
            //    Name = "Cheese Cake",
            //    Price = 18.95M,
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecake.jpg",
            //    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecakesmall.jpg",
            //});

            //modelBuilder.Entity<Product>().HasData(new Product
            //{
            //    ProductId = Guid.NewGuid(),
            //    Name = "Cherry Pie",
            //    Price = 15.95M,
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cherrypie.jpg",
            //    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cherrypiesmall.jpg",
            //});

            //modelBuilder.Entity<Product>().HasData(new Product
            //{
            //    ProductId = Guid.NewGuid(),
            //    Name = "Christmas Apple Pie",
            //    Price = 13.95M,
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/christmasapplepie.jpg",
            //    ImageThumbnailUrl =
            //        "https://gillcleerenpluralsight.blob.core.windows.net/files/christmasapplepiesmall.jpg",
            //});

            //modelBuilder.Entity<Product>().HasData(new Product
            //{
            //    ProductId = Guid.NewGuid(),
            //    Name = "Cranberry Pie",
            //    Price = 17.95M,
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cranberrypie.jpg",
            //    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cranberrypiesmall.jpg",
            //});

            //modelBuilder.Entity<Product>().HasData(new Product
            //{
            //    ProductId = Guid.NewGuid(),
            //    Name = "Peach Pie",
            //    Price = 15.95M,
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/peachpie.jpg",
            //    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/peachpiesmall.jpg",
            //});

            //modelBuilder.Entity<Product>().HasData(new Product
            //{
            //    ProductId = Guid.NewGuid(),
            //    Name = "Pumpkin Pie",
            //    Price = 12.95M,
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpie.jpg",
            //    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpiesmall.jpg",
            //});

            //modelBuilder.Entity<Product>().HasData(new Product
            //{
            //    ProductId = Guid.NewGuid(),
            //    Name = "Rhubarb Pie",
            //    Price = 15.95M,
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpie.jpg",
            //    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpiesmall.jpg",
            //});

            //modelBuilder.Entity<Product>().HasData(new Product
            //{
            //    ProductId = Guid.NewGuid(),
            //    Name = "Strawberry Pie",
            //    Price = 15.95M,
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypie.jpg",
            //    ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypiesmall.jpg",
            //});

            //modelBuilder.Entity<Product>().HasData(new Product
            //{
            //    ProductId = Guid.NewGuid(),
            //    Name = "Strawberry Cheese Cake",
            //    Price = 18.95M,
            //    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrycheesecake.jpg",
            //    ImageThumbnailUrl =
            //        "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrycheesecakesmall.jpg",
            //});

            modelBuilder.Entity<Product>()
            .Property(tb => tb.TimesBought)
            .HasDefaultValue(0);
        }
    }
}
