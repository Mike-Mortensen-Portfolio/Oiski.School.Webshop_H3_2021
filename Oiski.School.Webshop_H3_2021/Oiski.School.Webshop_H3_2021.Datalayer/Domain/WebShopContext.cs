﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.IO;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Domain
{
    public class WebshopContext : DbContext
    {
        public WebshopContext() { }
        public WebshopContext(DbContextOptions<WebshopContext> _options) : base(_options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

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

            _modelBuilder.Entity<ProductType>()
                .HasKey(pt => new { pt.ProductID, pt.TypeID });

            #region DATA SEEDING
            // PaymentMethod and DeliveryType has not been added yet !! TO-DO !!
            _modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerID = 1, FirstName = "Jasmin", LastName = "Nielsen", Email = "jasminnielsen97@gmail.com", Country = "Denmark", Address = "Nygade 38A, 2", City = "Aabenraa", ZipCode = 6200, PhoneNumber = "26139596" },
                new Customer { CustomerID = 2, FirstName = "Mike", LastName = "Mortensen", Email = "zhakalen@gmail.com", Country = "Denmark", Address = "Ringgade 65", City = "Sønderborg", ZipCode = 6400, PhoneNumber = "25987658" },
                new Customer { CustomerID = 3, FirstName = "Ulrik", LastName = "Larsen", Email = "ulrikLarsen@gmail.com", Country = "Denmark", Address = "Nordre Ringvej 20", City = "Vojens", ZipCode = 6500, PhoneNumber = "25496875" }
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

            // Type and ProductImages has not been added yet !! TO-DO !!
            _modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, Title = "High-waisted jeans", Description = "These pants are great for the Autumn weather.", Price = 40.58M, BrandName = "New Look", InStock = 125 },
                new Product { ProductID = 2, Title = "Skater skirt", Description = "The perfect outfit for your lower body.", Price = 26.25M, BrandName = "TopShop", InStock = 50 },
                new Product { ProductID = 3, Title = "Summer dress", Description = "Beer parties on the beach? This is your dress.", Price = 53.75M, BrandName = "NA-KD", InStock = 75 },
                new Product { ProductID = 4, Title = "Sneakers paradise, Nike", Description = "Love long walks? Choose these sneakers.", Price = 88, BrandName = "Nike", InStock = 130 },
                new Product { ProductID = 5, Title = "Warm knitted-sweater", Description = "Drink a warm cup of chocolate while cozing up in this sweater.", Price = 28, BrandName = "H&M", InStock = 109 },
                new Product { ProductID = 6, Title = "Simple Sneakers, Nike Air", Description = "Perfect for the daily life.", Price = 52, BrandName = "Nike", InStock = 180 },
                new Product { ProductID = 7, Title = "Simple T-shirt", Description = "Style it however you'd want to!", Price = 15, BrandName = "H&M Basic", InStock = 256 }
                );

            _modelBuilder.Entity<ProductType>().HasData(
                new ProductType { ProductID = 1, TypeID = 1 },
                new ProductType { ProductID = 1, TypeID = 12 },
                new ProductType { ProductID = 2, TypeID = 2 },
                new ProductType { ProductID = 2, TypeID = 3 },
                new ProductType { ProductID = 2, TypeID = 12 },
                new ProductType { ProductID = 3, TypeID = 4 },
                new ProductType { ProductID = 3, TypeID = 5 },
                new ProductType { ProductID = 3, TypeID = 13 },
                new ProductType { ProductID = 4, TypeID = 6 },
                new ProductType { ProductID = 4, TypeID = 7 },
                new ProductType { ProductID = 5, TypeID = 8 },
                new ProductType { ProductID = 5, TypeID = 9 },
                new ProductType { ProductID = 5, TypeID = 11 },
                new ProductType { ProductID = 6, TypeID = 6 },
                new ProductType { ProductID = 6, TypeID = 7 },
                new ProductType { ProductID = 7, TypeID = 8 },
                new ProductType { ProductID = 7, TypeID = 11 }
                );

            _modelBuilder.Entity<Entities.Type>().HasData(
                new Entities.Type { TypeID = 1, Name = "Jeans" },
                new Entities.Type { TypeID = 2, Name = "Skirt" },
                new Entities.Type { TypeID = 3, Name = "Skater-Skirt" },
                new Entities.Type { TypeID = 4, Name = "Dress" },
                new Entities.Type { TypeID = 5, Name = "Short-Dress" },
                new Entities.Type { TypeID = 6, Name = "Footwear" },
                new Entities.Type { TypeID = 7, Name = "Sneakers" },
                new Entities.Type { TypeID = 8, Name = "Sweater" },
                new Entities.Type { TypeID = 9, Name = "Knitted-Sweater" },
                new Entities.Type { TypeID = 10, Name = "T-shirt" },
                new Entities.Type { TypeID = 11, Name = "Upper-wear" },
                new Entities.Type { TypeID = 12, Name = "Bottom" },
                new Entities.Type { TypeID = 13, Name = "Full-body" }
                );

            // Images need to be put in under ImageStream !! TO-DO !!
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
