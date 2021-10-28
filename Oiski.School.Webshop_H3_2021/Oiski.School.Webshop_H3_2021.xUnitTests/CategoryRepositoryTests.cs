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
    public class CategoryRepositoryTests
    {
        public CategoryRepositoryTests()
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
        public void Get_All_Categories()
        {
            // ARRANGE:
            int contextCount;

            // ACT: Getting all categories in the Service and then on the Context.
            int count = service.Category.GetAllAsync()
                .GetAwaiter()
                .GetResult()
                .Count;

            using (var context = new WebshopContext())
            {
                contextCount = context.Set<Category>()
                    .Count();
            }

            // ASSERT: Comparing the amount on both the Service and the Context.
            Assert.True(count == contextCount);
        }

        [Fact]
        public void Get_Category_By_ID()
        {
            // ARRANGE: Setting the search ID to get.
            int searchID = 1;
            Category contextCategory = null;

            // ACT: Getting the CategoryID through the Service, then through the Context.
            ICategory category = service.Category.GetByIDAsync(searchID)
                .GetAwaiter()
                .GetResult();

            using (var context = new WebshopContext())
            {
                contextCategory = context.Set<Category>()
                    .SingleOrDefault(c => c.CategoryID == searchID);
            }

            // ASSERT: Checking if the Category is NotNull, then we're comparing the two IDs against each other on Service and Context.
            Assert.NotNull(contextCategory);
            Assert.True(category.CategoryID == contextCategory.CategoryID);
        }

        [Fact]
        public void Add_Category()
        {
            // ARRANGE: Creating the new Category to be added.
            ICategory newCategory = new CategoryDTO
            {
                Name = "Accessories"
            };
            bool success = false;
            Category contextCategory = null;

            // ACT: Adding the new Category through the WebshopService, then finding it in the WebshopContext.
            success = service.Category.AddAsync(newCategory).Result;

            using (var context = new WebshopContext())
            {
                contextCategory = context.Set<Category>()
                    .SingleOrDefault(c => c.Name == "Accessories");
            }

            // ASSERT: Checking the contextCategory is NotNull, then comparing if the success and contextCategory.Name are equals "string"
            Assert.NotNull(contextCategory);
            Assert.True(success && contextCategory.Name == "Accessories");
        }

        [Fact]
        public void Update_Category()
        {
            // ARRANGE: Adding the Category there needs update.
            ICategory updatedCategory = new CategoryDTO
            {
                CategoryID = 1,
                Name = "Updated Name"
            };
            bool success = false;
            Category contextCategory = null;

            // ACT: Updating the Category through the WebshopService, then searching for it in the WebshopContext.
            success = service.Category.UpdateAsync(updatedCategory).Result;

            using (var context = new WebshopContext())
            {
                contextCategory = context.Set<Category>()
                    .SingleOrDefault(c => c.Name == "Updated Name");
            }

            // ASSERT: Checking if the contextCategory is NotNull, then comparing if the success and contextCategory.Name are equals "string" 
            Assert.NotNull(contextCategory);
            Assert.True(success && contextCategory.Name == "Updated Name");
        }

        [Fact]
        public void Remove_Category()
        {
            // ARRANGE: Setting up the Category there needs removal.
            ICategory removeCategory = new CategoryDTO
            {
                CategoryID = 1,
                Name = "Removed"
            };
            bool success = false;
            Category contextCategory = null;

            // ACT: Removing the Category on the WebshopService, then checking for it on the WebshopContext.
            success = service.Category.RemoveAsync(removeCategory).Result;

            using (var context = new WebshopContext())
            {
                contextCategory = context.Set<Category>()
                    .SingleOrDefault(c => c.Name == "Removed");
            }

            // ASSERT: Checking to make sure that the searched Category is Null, then checking that success changed to True.
            Assert.Null(contextCategory);
            Assert.True(success);
        }

        [Fact]
        public void Get_All_Products_In_A_Category()
        {
            // ARRANGE: 
            int categoryID = 1;
            int contextCount;
            IProduct product = null; 

            // ACT: Getting Category by its ID then finding all Products with that CategoryID, then finding that ID on the context.
            ICategory category = service.Category.GetByIDAsync(categoryID).Result;

            IReadOnlyList<IProduct> products = category.GetProductsAsync().Result;

            using (var context = new WebshopContext())
            {
                contextCount = context.Products
                    .Where(p => p.CategoryID == categoryID)
                    .Count();
            }

            // ASSERT: Comparing the count of Products with the same CategoryID on the Service and Context.
            Assert.True(contextCount == products.Count);
        }
    }
}
