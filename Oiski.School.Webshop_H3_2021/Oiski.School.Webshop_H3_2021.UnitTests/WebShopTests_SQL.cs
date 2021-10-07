using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Oiski.School.Webshop_H3_2021.UnitTests
{
    public class WebShopTests_SQL
    {
        [Fact]
        public void Add_Product_To_DB()
        {
            // ARRANGE: Delete old DB and then create a new one.
            using (var context = new WebshopContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            // ACT: Adding new Product data.
            WebshopService.Access.Add(new Product
            {
                Title = "Skinny Jeans",
                Description = "Strechable pants with a skinny jeans look.",
                Price = 30.43M,
                BrandName = "H&M",
                InStock = 146,
            });
            WebshopService.Access.Add(new Datalayer.Entities.Type
            {
                Name = "Skinny-Jeans"
            });
            WebshopService.Access.Add(new ProductType
            {
                ProductID = 6,
                TypeID = 1,
            });
            WebshopService.Access.Add(new ProductType
            {
                ProductID = 6,
                TypeID = 10,
            });

            // ASSERT: Getting all of the products, then checking if the new Product is in Products
            using (var context = new WebshopContext())
            {
                Assert.Equal(6, context.Products.Count());
                Assert.Equal("Skinny Jeans", context.Products.Where(p => p.Title == "Skinny Jeans").Single().Title);
            }
        }

        [Fact]
        public void Update_Customer_In_DB()
        {
            // ARRANGE: Delete old DB and then create a new one.
            using (var context = new WebshopContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            // ACT: Finding the first customer, then changing FirstName, before we then pass it through to Update.
            using (var context = new WebshopContext())
            {
                var customer = context.Customers
                    .FirstOrDefault();

                customer.FirstName = "Bente";

                WebshopService.Access.Update(customer);
            }

            // ASSERT: Finding all customers, then we check if there is one with the FirstName of "Bente" in Customers.
            using (var context = new WebshopContext())
            {
                Assert.Equal(3, context.Customers.Count());
                Assert.Equal("Bente", context.Customers.Where(c => c.FirstName == "Bente").Single().FirstName);
            }
        }

        [Fact]
        public void Remove_Product_From_DB()
        {
            // ARRANGE: Delete old DB and then create a new one.
            using (var context = new WebshopContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            int productID;

            // ACT: Getting the last Product and saving the ID to then pass it down to remove.
            using (var context = new WebshopContext())
            {
                var product = context.Products
                    .FirstOrDefault();

                productID = product.ProductID;

                WebshopService.Access.Remove(product);
            }

            // ASSERT: Finding the deleted productID, then checking to see if it has turned Null.
            using (var context = new WebshopContext())
            {
                var result = context.Products.Find(productID);
                Assert.Null(result);
            }
        }

        [Fact]
        public void Find_All_Types_On_Product()
        {
            // ARRANGE:
            using (var context = new WebshopContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            int productID;

            // ACT:
            using (var context = new WebshopContext())
            {
                var product = context.Products
                    .Where(p => p.ProductID == 2)
                    .FirstOrDefault();

                productID = product.ProductID;
            }

            // ASSERT:
            using (var context = new WebshopContext())
            {
                var product = WebshopService.Access.Find<Product>(p => p.ProductID == 2)
                    .Include(p => p.Types)
                    .ThenInclude(pt => pt.Type)
                    .FirstOrDefault();

                context.Products.Find(2);
                int count = product.Types.Count();

                Assert.Equal(2, count);
            }
        }
    }
}
