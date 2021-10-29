using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Oiski.School.Webshop_H3_2021.Servicelayer;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Oiski.School.Webshop_H3_2021.xUnitTests
{
    public class ProductRepositoryTests
    {
        public ProductRepositoryTests()
        {
            service = new WebshopService();

            using (var context = new WebshopContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        private readonly IWebshopService service;

        [Fact]
        public void Get_All_Products()
        {
            // ARRANGE:
            int contextCount;

            // ACT: Get all Products through WebshopService and then all Products through WebshopContext.
            int count = service.Product.GetAllAsync()
                .GetAwaiter()
                .GetResult()
                .Count;

            using (var context = new WebshopContext())
            {
                contextCount = context.Products
                    .Count();
            }

            // ASSERT: Compare the amount on both the WebshopService and WebshopContext.
            Assert.True(count == contextCount);
        }

        [Fact]
        public void Get_Product_By_ID()
        {
            // ARRANGE:
            int searchID = 2;
            Product contextProduct = null;

            // ACT: Retrieving a Product on the WebshopService and then on the WebshopContext.
            IProduct product = service.Product.GetByIDAsync(searchID)
                .GetAwaiter()
                .GetResult();

            using (var context = new WebshopContext())
            {
                contextProduct = context.Products
                    .SingleOrDefault(p => p.ProductID == searchID);
            }

            // ASSERT: Making sure the Product we retrieve on the WebshopContext isn't Null, then comparing the ProductID on the Service and DBContext.
            Assert.NotNull(product);
            Assert.True(product.ProductID == contextProduct.ProductID);
        }

        [Fact]
        public void Get_Product_By_Brand()
        {
            // ARRANGE:
            int brandID = 1;
            int contextCount;

            // ACT: Get all Products with the same BrandID through WebshopService and then through WebshopContext.
            int count = service.Product.GetByBrandAsync(brandID)
                .GetAwaiter()
                .GetResult()
                .Count;

            using (var context = new WebshopContext())
            {
                contextCount = context.Products
                    .Where(p => p.BrandID == brandID)
                    .Count();
            }

            // ASSERT: Compare the amount on both the WebshopService and WebshopContext where it finds the same BrandID.
            Assert.True(count == contextCount);
        }

        [Fact]
        public void Get_Product_By_Category()
        {
            // ARRANGE:
            int categoryID = 3;
            int contextCount;

            // ACT: Get all Products with the same CategoryID through WebshopService and then through WebshopContext.
            int count = service.Product.GetByCategoryAsync(categoryID)
                .GetAwaiter()
                .GetResult()
                .Count;

            using (var context = new WebshopContext())
            {
                contextCount = context.Products
                    .Where(p => p.CategoryID == categoryID)
                    .Count();
            }

            // ASSERT: Compare the amount on both the WebshopService and WebshopContext where it finds the same CategoryID.
            Assert.True(count == contextCount);
        }

        [Fact]
        public void Add_Product()
        {
            // ARRANGE: Creating a new Product to push up.
            IProduct newProduct = new ProductDTO
            {
                BrandID = 1,
                CategoryID = 3,
                Title = "Fancy dress",
                Description = "Wear this to the most luxury parties.",
                Price = 43.54M,
                InStock = 435
            };
            bool success = false;
            Product contextProduct = null;

            // ACT: Adding the new Product through our Service, then finding it through the Context.
            success = service.Product.AddAsync(newProduct).Result;

            using (var context = new WebshopContext())
            {
                contextProduct = context.Products
                    .SingleOrDefault(p => p.Title == newProduct.Title);
            }

            // ASSERT: Checking if the Product found in Context is Null or not, then comparing to check if the success and the contextProduct.Title are equal with "string"
            Assert.NotNull(contextProduct);
            Assert.True(success);
        }

        [Fact]
        public void Update_Product()
        {
            // ARRANGE: Creating a new Product where we set the ProductID on the Product we wanna Update.
            IProduct updatedProduct = new ProductDTO
            {
                ProductID = 1,
                BrandID = 2,
                CategoryID = 2,
                Price = 43,
                Title = "New Title",
                Description = "New Description",
                InStock = 54
            };
            bool success = false;
            Product contextProduct = null;

            // ACT: Updating the new Product through our Service, then finding it through the Context.
            success = service.Product.UpdateAsync(updatedProduct).Result;

            using (var context = new WebshopContext())
            {
                contextProduct = context.Products
                    .SingleOrDefault(p => p.Description == updatedProduct.Description);
            }

            // ASSERT: Checking if the Product found in Context is Null or not, then comparing to check if the success and the contextProduct.Title are equal with "string"
            Assert.NotNull(contextProduct);
            Assert.True(success);
        }

        [Fact]
        public void Remove_Product()
        {
            // ARRANGE: Creating a new Product where we set the ProductID on the Product we wanna Update.
            IProduct deletedProduct = new ProductDTO
            {
                ProductID = 1,
                BrandID = 2,
                CategoryID = 2,
                Price = 0,
                Title = "",
                Description = "",
                InStock = 0
            };
            bool success = false;
            Product contextProduct = null;

            // ACT: Removing the new Product through our Service, then trying finding it through the Context.
            success = service.Product.RemoveAsync(deletedProduct).Result;

            using (var context = new WebshopContext())
            {
                contextProduct = context.Products
                    .SingleOrDefault(p => p.ProductID == deletedProduct.ProductID);
            }

            // ASSERT: Checking if the Product is Null/Not in Context, then checking if our success has become true when Removing the Product.
            Assert.Null(contextProduct);
            Assert.True(success);
        }

        [Fact]
        public void Get_Brand_Extension()
        {
            // ARRANGE:            
            IProduct product = null;
            using (var context = new WebshopContext())
            {
                product = context.Products
                    .Select(p => new ProductDTO
                    {
                        BrandID = p.BrandID,
                        CategoryID = p.CategoryID,
                        Description = p.Description,
                        InStock = p.InStock,
                        Price = p.Price,
                        ProductID = p.ProductID,
                        Title = p.Title
                    }).FirstOrDefault();
            }

            // ACT: Getting the Brand based on the Product we got from ARRANGE.
            IBrand brand = product.GetBrandAsync().Result;

            // ASSET: Checking the brand isn't Null.
            Assert.NotNull(brand);
        }

        [Fact]
        public void Get_Category_Extension()
        {
            // ARRANGE:            
            IProduct product = null;
            using (var context = new WebshopContext())
            {
                product = context.Products
                    .Select(p => new ProductDTO
                    {
                        BrandID = p.BrandID,
                        CategoryID = p.CategoryID,
                        Description = p.Description,
                        InStock = p.InStock,
                        Price = p.Price,
                        ProductID = p.ProductID,
                        Title = p.Title
                    }).FirstOrDefault();
            }

            // ACT: Getting the Category based on the Product we got from ARRANGE.
            ICategory category = product.GetCategoryAsync().Result;

            // ASSET: Checking the category isn't Null.
            Assert.NotNull(category);
        }

        [Fact]
        public void Get_Images_Extension()
        {
            // ARRANGE:
            IProduct product = null;
            IReadOnlyList<IProductImage> productImages;
            using (var context = new WebshopContext())
            {
                product = context.Products
                    .Select(p => new ProductDTO
                    {
                        BrandID = p.BrandID,
                        CategoryID = p.CategoryID,
                        Description = p.Description,
                        InStock = p.InStock,
                        Price = p.Price,
                        ProductID = p.ProductID,
                        Title = p.Title

                    }).FirstOrDefault();
            }

            // ACT: Getting all of the Images in the above product we get from the WebshopContext.
            productImages = product.GetImagesAsync().Result;

            // ASSERT: Checking that it ain't Null.
            Assert.NotNull(productImages);
        }

        [Fact]
        public void Get_Orders_Extension()
        {
            // ARRANGE:
            IProduct product = null;
            IReadOnlyList<IOrder> orders = null;
            using (var context = new WebshopContext())
            {
                product = context.Products
                    .Select(p => new ProductDTO
                    {
                        BrandID = p.BrandID,
                        CategoryID = p.CategoryID,
                        Description = p.Description,
                        InStock = p.InStock,
                        Price = p.Price,
                        ProductID = p.ProductID,
                        Title = p.Title

                    }).FirstOrDefault();
            }

            // ACT: Getting all of the orders existing in the above Product from the WebshopContext.
            orders = product.GetOrdersAsync().Result;

            // ASSERT: Checking that the IReadOnlyList<IOrder> isn't Null.
            Assert.NotNull(orders);
        }
    }
}
