using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.IO;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Domain
{
    public class WebshopContext : DbContext
    {
        public WebshopContext() { }
        public WebshopContext(DbContextOptions<WebshopContext> _options) : base (_options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder _optionsBuilder)
        {
            if (!_optionsBuilder.IsConfigured)
            {
                _optionsBuilder
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WebShopDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder _modelBuilder)
        {
            _modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.ProductID, op.OrderID });

            #region DATA SEED
            _modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerID = 1, UserID = 3, FirstName = "Jasmin", LastName = "Nielsen", Email = "jasminnielsen97@gmail.com", Country = "Denmark", Address = "Nygade 38A, 2", City = "Aabenraa", ZipCode = 6200, PhoneNumber = "26139596" },
                new Customer { CustomerID = 2, UserID = 1, FirstName = "Mike", LastName = "Mortensen", Email = "zhakalen@gmail.com", Country = "Denmark", Address = "Ringgade 65", City = "Sønderborg", ZipCode = 6400, PhoneNumber = "25987658" },
                new Customer { CustomerID = 3, UserID = 2, FirstName = "Ulrik", LastName = "Larsen", Email = "ulrikLarsen@gmail.com", Country = "Denmark", Address = "Nordre Ringvej 20", City = "Vojens", ZipCode = 6500, PhoneNumber = "25496875" },
                new Customer { CustomerID = 4, FirstName = "Ulrik", LastName = "Larsen", Email = "ullelarsen@gmail.com", Country = "Denmark", Address = "Nordre Ringvej 20", City = "Vojens", ZipCode = 6500, PhoneNumber = "25496875" }
                );

            _modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, CustomerID = 2, Password = "P@ssw0rd", IsAdmin = true },
                new User { UserID = 2, CustomerID = 3, Password = "P@ssw0rd", IsAdmin = false },
                new User { UserID = 3, CustomerID = 1, Password = "P@ssw0rd", IsAdmin = true }
                );

            _modelBuilder.Entity<Order>().HasData(
                new Order { OrderID = 1, CustomerID = 2, OrderDate = DateTime.Parse("10/06-2021") },
                new Order { OrderID = 2, CustomerID = 1, OrderDate = DateTime.Parse("10/09-2021") }
                );

            _modelBuilder.Entity<OrderProduct>().HasData(
                new OrderProduct { OrderID = 1, ProductID = 1, Quantity = 2 },
                new OrderProduct { OrderID = 1, ProductID = 4 },
                new OrderProduct { OrderID = 1, ProductID = 5 },
                new OrderProduct { OrderID = 2, ProductID = 2 },
                new OrderProduct { OrderID = 2, ProductID = 3 }
                );

            _modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, Title = "High-waisted jeans", Description = "These pants are great for the Autumn weather.", BrandID = 1, CategoryID = 2, Price = 40.58M, InStock = 125 },
                new Product { ProductID = 2, Title = "Skater skirt", Description = "The perfect outfit for your lower body.", BrandID = 2, CategoryID = 2, Price = 26.25M, InStock = 50 },
                new Product { ProductID = 3, Title = "Summer dress", Description = "Beer parties on the beach? This is your dress.", BrandID = 4, CategoryID = 3, Price = 53.75M, InStock = 75 },
                new Product { ProductID = 4, Title = "Sneakers paradise, Nike", Description = "Love long walks? Choose these sneakers.", BrandID = 3, CategoryID = 4, Price = 88, InStock = 130 },
                new Product { ProductID = 5, Title = "Warm knitted-sweater", Description = "Drink a warm cup of chocolate while cozing up in this sweater.", BrandID = 1, CategoryID = 1, Price = 28, InStock = 109 },
                new Product { ProductID = 6, Title = "Simple Sneakers, Nike Air", Description = "Perfect for the daily life.", BrandID = 3, CategoryID = 4, Price = 52, InStock = 180 },
                new Product { ProductID = 7, Title = "Simple T-shirt", Description = "Style it however you'd want to!", BrandID = 1, CategoryID = 1, Price = 15, InStock = 256 }
                );

            _modelBuilder.Entity<Brand>().HasData(
                new Brand { BrandID = 1, Name = "H&M"},
                new Brand { BrandID = 2, Name = "NA-KD" },
                new Brand { BrandID = 3, Name = "Nike" },
                new Brand { BrandID = 4, Name = "ASOS" }
                );

            _modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Upper body"},
                new Category { CategoryID = 2, Name = "Lower body" },
                new Category { CategoryID = 3, Name = "Full body" },
                new Category { CategoryID = 4, Name = "Footwear" }
                );

            _modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage { ProductImageID = 1, ProductID = 1, ImageURL = @"Clothes/Bottoms/High-Waisted-Jeans-Front.jpg", Title = "High-Waisted-Jeans-Front" },
                new ProductImage { ProductImageID = 2, ProductID = 1, ImageURL = @"Clothes/Bottoms/High-Waisted-Jeans-Back.jpg", Title = "High-Waisted-Jeans-Back" },
                new ProductImage { ProductImageID = 3, ProductID = 2, ImageURL = @"Clothes/Bottoms/Skater-Skirt-Front.jpg", Title = "Skater-Skirt-Front" },
                new ProductImage { ProductImageID = 4, ProductID = 2, ImageURL = @"Clothes/Bottoms/Skater-Skirt-Back.jpg", Title = "Skater-Skirt-Back" },
                new ProductImage { ProductImageID = 5, ProductID = 3, ImageURL = @"Clothes/FullBody/Summer-Dress-Front.jpg", Title = "Summer-Dress-Front" },
                new ProductImage { ProductImageID = 6, ProductID = 3, ImageURL = @"Clothes/FullBody/Summer-Dress-Back.jpg", Title = "Summer-Dress-Back" },
                new ProductImage { ProductImageID = 7, ProductID = 4, ImageURL = @"Clothes/Shoes/Sneakers-Paradise-Front.jpg", Title = "Sneakers-Paradise-Front" },
                new ProductImage { ProductImageID = 8, ProductID = 4, ImageURL = @"Clothes/Shoes/Sneakers-Paradise-Back.jpg", Title = "Sneakers-Paradise-Back" },
                new ProductImage { ProductImageID = 9, ProductID = 5, ImageURL = @"Clothes/Top/Warm-Knitted-Sweater-Front.jpg", Title = "Warm-Knitted-Sweater-Front" },
                new ProductImage { ProductImageID = 10, ProductID = 5, ImageURL = @"Clothes/Top/Warm-Knitted-Sweater-Back.jpg", Title = "Warm-Knitted-Sweater-Back" },
                new ProductImage { ProductImageID = 11, ProductID = 6, ImageURL = @"Clothes/Shoes/Simple-Sneakers-Front.jpg", Title = "Simple-Sneakersle-Front" },
                new ProductImage { ProductImageID = 12, ProductID = 6, ImageURL = @"Clothes/Shoes/Simple-Sneakers-Back.jpg", Title = "Simple-Sneakers-Back" },
                new ProductImage { ProductImageID = 13, ProductID = 7, ImageURL = @"Clothes/Top/Simple-T-shirt-Front.jpg", Title = "Simple-T-shirt-Front" },
                new ProductImage { ProductImageID = 14, ProductID = 7, ImageURL = @"Clothes/Top/Simple-T-shirt-Back.jpg", Title = "Simple-T-shirt-Back" }
            );
            #endregion
        }
    }
}
