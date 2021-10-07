using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Domain
{
    public class WebShopContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder _optionsBuilder)
        {
            _optionsBuilder
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WebShopDb;Trusted_Connection=True;");
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
            //    new Customer { CustomerID = 1, FirstName = "Jasmin", LastName = "Nielsen", Email = "jasminnielsen97@gmail.com", Country = "Denmark", Address = "Nygade 38A, 2", City = "Aabenraa", ZIP = 6200, PhoneNumber = "26139596" },
            //    new Customer { CustomerID = 2, FirstName = "Mike", LastName = "Mortensen", Email = "zhakalen@gmail.com", Country = "Denmark", Address = "Ringgade 65", City = "Sønderborg", ZIP = 6400, PhoneNumber = "25987658" },
            //    new Customer { CustomerID = 3, FirstName = "Ulrik", LastName = "Larsen", Email = "ulrikLarsen@gmail.com", Country = "Denmark", Address = "Nordre Ringvej 20", City = "Vojens", ZIP = 6500, PhoneNumber = "25496875" }
            //    );

            //// List<Product> PreviousOrders has not been added yet !! TO-DO !!
            //_modelBuilder.Entity<CustomerLogin>().HasData(
            //    new CustomerLogin { CustomerLoginID = 1, CustomerID = 2, Password = "P@ssw0rd" },
            //    new CustomerLogin { CustomerLoginID = 2, CustomerID = 3, Password = "P@ssw0rd" }
            //    );

            //// List<Product> has not been added yet !! TO-DO !!
            //_modelBuilder.Entity<Order>().HasData(
            //    new Order { OrderID = 1, CustomerID = 2, OrderDate = DateTime.Parse("10/06-2021") },
            //    new Order { OrderID = 2, CustomerID = 1, OrderDate = DateTime.Parse("10/09-2021") }
            //    );

            //// Type and ProductImages has not been added yet !! TO-DO !!
            //_modelBuilder.Entity<Product>().HasData(
            //    new Product { ProductID = 1, Title = "High-waisted jeans", Description = "These pants are great for the Autumn weather.", Price = 40.58, BrandName = "New Look", InStock = 125 },
            //    new Product { ProductID = 2, Title = "Skater skirt", Description = "The perfect outfit for your lower body.", Price = 26.25, BrandName = "TopShop", InStock = 50},
            //    new Product { ProductID = 3, Title = "Summer dress", Description = "Beer parties on the beach? This is your dress.", Price = 53.75, BrandName = "NA-KD", InStock = 75 },
            //    new Product { ProductID = 4, Title = "Sneakers paradise", Description = "Love long walks? Choose these sneakers.", Price = 88, BrandName = "Nike", InStock = 130 },
            //    new Product { ProductID = 5, Title = "Warm knitted-sweater", Description = "Drink a warm cup of chocolate while cozing up in this sweater.", Price = 28, BrandName = "H&M", InStock = 109 }
            //    );

            //_modelBuilder.Entity<Entities.Type>().HasData(
            //    new Entities.Type { TypeID = 1, Name = "Jeans" },
            //    new Entities.Type { TypeID = 2, Name = "Skirt" },
            //    new Entities.Type { TypeID = 3, Name = "Dress" },
            //    new Entities.Type { TypeID = 4, Name = "Shoe" },
            //    new Entities.Type { TypeID = 5, Name = "Sweater" }
            //    );

            //// Images need to be put in under ImageStream !! TO-DO !!
            //_modelBuilder.Entity<ProductImages>().HasData(
            //    new ProductImages { ImageID = 1, ImageStream = 0, Title = "High-Waisted-Jeans-SideWays" },
            //    new ProductImages { ImageID = 2, ImageStream = 0, Title = "High-Waisted-Jeans-Front" },
            //    new ProductImages { ImageID = 3, ImageStream = 0, Title = "High-Waisted-Jeans-Back" },
            //    new ProductImages { ImageID = 4, ImageStream = 0, Title = "Skater-Skirt-SideWays" },
            //    new ProductImages { ImageID = 5, ImageStream = 0, Title = "Skater-Skirt-Front" },
            //    new ProductImages { ImageID = 5, ImageStream = 0, Title = "Skater-Skirt-Back" }, 
            //    new ProductImages { ImageID = 5, ImageStream = 0, Title = "Summer-Dress-SideWays" }, 
            //    new ProductImages { ImageID = 5, ImageStream = 0, Title = "Summer-Dress-Front" },
            //    new ProductImages { ImageID = 5, ImageStream = 0, Title = "Summer-Dress-Back" },
            //    new ProductImages { ImageID = 5, ImageStream = 0, Title = "Sneakers-Paradise-SideWays" },
            //    new ProductImages { ImageID = 5, ImageStream = 0, Title = "Sneakers-Paradise-Front" },
            //    new ProductImages { ImageID = 5, ImageStream = 0, Title = "Sneakers-Paradise-Back" },
            //    new ProductImages { ImageID = 5, ImageStream = 0, Title = "Warm-Knitted-Sweater-SideWays" },
            //    new ProductImages { ImageID = 5, ImageStream = 0, Title = "Warm-Knitted-Sweater-SideWays" },
            //    new ProductImages { ImageID = 5, ImageStream = 0, Title = "Warm-Knitted-Sweater-SideWays" }
            //);
            #endregion
        }
    }
}
