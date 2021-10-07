using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Domain
{
    public class WebshopContext : DbContext
    {
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
            //// PaymentMethod and DeliveryType has not been added yet !! TO-DO !!
            //_modelBuilder.Entity<Customer>().HasData(
            //    new Customer { CustomerID = 1, FirstName = "Jasmin", LastName = "Nielsen", Email = "jasminnielsen97@gmail.com", Country = "Denmark", Address = "Nygade 38A, 2", City = "Aabenraa", ZipCode = 6200, PhoneNumber = "26139596" },
            //    new Customer { CustomerID = 2, FirstName = "Mike", LastName = "Mortensen", Email = "zhakalen@gmail.com", Country = "Denmark", Address = "Ringgade 65", City = "Sønderborg", ZipCode = 6400, PhoneNumber = "25987658" },
            //    new Customer { CustomerID = 3, FirstName = "Ulrik", LastName = "Larsen", Email = "ulrikLarsen@gmail.com", Country = "Denmark", Address = "Nordre Ringvej 20", City = "Vojens", ZipCode = 6500, PhoneNumber = "25496875" }
            //    );

            //_modelBuilder.Entity<CustomerLogin>().HasData(
            //    new CustomerLogin { CustomerLoginID = 1, CustomerID = 2, Password = "P@ssw0rd" },
            //    new CustomerLogin { CustomerLoginID = 2, CustomerID = 3, Password = "P@ssw0rd" }
            //    );

            //_modelBuilder.Entity<Order>().HasData(
            //    new Order { OrderID = 1, CustomerID = 2, OrderDate = DateTime.Parse("10/06-2021") },
            //    new Order { OrderID = 2, CustomerID = 1, OrderDate = DateTime.Parse("10/09-2021") }
            //    );

            //_modelBuilder.Entity<OrderProduct>.HasData(
            //    new OrderProduct { OrderID = 1, ProductID = 1 },
            //    new OrderProduct { OrderID = 1, ProductID = 4 },
            //    new OrderProduct { OrderID = 1, ProductID = 5 },
            //    new OrderProduct { OrderID = 2, ProductID = 2 },
            //    new OrderProduct { OrderID = 2, ProductID = 3 }
            //    );

            //// Type and ProductImages has not been added yet !! TO-DO !!
            //_modelBuilder.Entity<Product>().HasData(
            //    new Product { ProductID = 1, Title = "High-waisted jeans", Description = "These pants are great for the Autumn weather.", Price = 40.58M, BrandName = "New Look", InStock = 125 },
            //    new Product { ProductID = 2, Title = "Skater skirt", Description = "The perfect outfit for your lower body.", Price = 26.25M, BrandName = "TopShop", InStock = 50 },
            //    new Product { ProductID = 3, Title = "Summer dress", Description = "Beer parties on the beach? This is your dress.", Price = 53.75M, BrandName = "NA-KD", InStock = 75 },
            //    new Product { ProductID = 4, Title = "Sneakers paradise", Description = "Love long walks? Choose these sneakers.", Price = 88, BrandName = "Nike", InStock = 130 },
            //    new Product { ProductID = 5, Title = "Warm knitted-sweater", Description = "Drink a warm cup of chocolate while cozing up in this sweater.", Price = 28, BrandName = "H&M", InStock = 109 }
            //    );

            //_modelBuilder.Entity<ProductType>().HasData(
            //    new ProductType { ProductID = 1, TypeID = 1 },
            //    new ProductType { ProductID = 2, TypeID = 2 },
            //    new ProductType { ProductID = 2, TypeID = 3 },
            //    new ProductType { ProductID = 3, TypeID = 4 },
            //    new ProductType { ProductID = 3, TypeID = 5 },
            //    new ProductType { ProductID = 4, TypeID = 6 },
            //    new ProductType { ProductID = 4, TypeID = 7 },
            //    new ProductType { ProductID = 5, TypeID = 8 },
            //    new ProductType { ProductID = 5, TypeID = 9 }
            //    );

            //_modelBuilder.Entity<Entities.Type>().HasData(
            //    new Entities.Type { TypeID = 1, Name = "Jeans" },
            //    new Entities.Type { TypeID = 2, Name = "Skirt" },
            //    new Entities.Type { TypeID = 3, Name = "Skater-Skirt" },
            //    new Entities.Type { TypeID = 4, Name = "Dress" },
            //    new Entities.Type { TypeID = 5, Name = "Short-Dress" },
            //    new Entities.Type { TypeID = 6, Name = "Footwear" },
            //    new Entities.Type { TypeID = 7, Name = "Sneakers" },
            //    new Entities.Type { TypeID = 8, Name = "Sweater" },
            //    new Entities.Type { TypeID = 9, Name = "Knitted-Sweater" }
            //    );

            //// Images need to be put in under ImageStream !! TO-DO !!
            //_modelBuilder.Entity<ProductImage>().HasData(
            //    new ProductImage { ProductImageID = 1, ProductID = 1, ImageStream = new byte[] { }, Title = "High-Waisted-Jeans-SideWays" },
            //    new ProductImage { ProductImageID = 2, ProductID = 1, ImageStream = new byte[] { }, Title = "High-Waisted-Jeans-Front" },
            //    new ProductImage { ProductImageID = 3, ProductID = 1, ImageStream = new byte[] { }, Title = "High-Waisted-Jeans-Back" },
            //    new ProductImage { ProductImageID = 4, ProductID = 2, ImageStream = new byte[] { }, Title = "Skater-Skirt-SideWays" },
            //    new ProductImage { ProductImageID = 5, ProductID = 2, ImageStream = new byte[] { }, Title = "Skater-Skirt-Front" },
            //    new ProductImage { ProductImageID = 5, ProductID = 2, ImageStream = new byte[] { }, Title = "Skater-Skirt-Back" },
            //    new ProductImage { ProductImageID = 5, ProductID = 3, ImageStream = new byte[] { }, Title = "Summer-Dress-SideWays" },
            //    new ProductImage { ProductImageID = 5, ProductID = 3, ImageStream = new byte[] { }, Title = "Summer-Dress-Front" },
            //    new ProductImage { ProductImageID = 5, ProductID = 3, ImageStream = new byte[] { }, Title = "Summer-Dress-Back" },
            //    new ProductImage { ProductImageID = 5, ProductID = 4, ImageStream = new byte[] { }, Title = "Sneakers-Paradise-SideWays" },
            //    new ProductImage { ProductImageID = 5, ProductID = 4, ImageStream = new byte[] { }, Title = "Sneakers-Paradise-Front" },
            //    new ProductImage { ProductImageID = 5, ProductID = 4, ImageStream = new byte[] { }, Title = "Sneakers-Paradise-Back" },
            //    new ProductImage { ProductImageID = 5, ProductID = 5, ImageStream = new byte[] { }, Title = "Warm-Knitted-Sweater-SideWays" },
            //    new ProductImage { ProductImageID = 5, ProductID = 5, ImageStream = new byte[] { }, Title = "Warm-Knitted-Sweater-SideWays" },
            //    new ProductImage { ProductImageID = 5, ProductID = 5, ImageStream = new byte[] { }, Title = "Warm-Knitted-Sweater-SideWays" }
            //);
            #endregion
        }
    }
}
