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
    public class BrandRepositoryTests
    {
        public BrandRepositoryTests()
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
        public void Get_All_Brands()
        {
            // ARRANGE:
            int contextCount;

            // ACT: Get all Brands through WebshopService and then all Brands through WebshopContext.
            int count = service.Brand.GetAllAsync()
                .GetAwaiter()
                .GetResult()
                .Count;

            using (var context = new WebshopContext())
            {
                contextCount = context.Set<Brand>()
                    .Count();
            }

            // ASSERT: Compare the amount of Brands on both the WebshopService and WebshopContext.
            Assert.True(count == contextCount);
        }

        [Fact]
        public void Get_Brand_By_ID()
        {
            // ARRANGE:
            int searchID = 1;
            Brand contextBrand = null;

            // ACT: Get a Brand by specific ID through WebshopService and then through WebshopContext.
            IBrand brand = service.Brand.GetByIDAsync(searchID)
                .GetAwaiter()
                .GetResult();

            using (var context = new WebshopContext())
            {
                contextBrand = context.Set<Brand>()
                    .SingleOrDefault(b => b.BrandID == searchID);
            }

            // ASSERT: Compare the amount of Brands on both the WebshopService and WebshopContext.
            Assert.NotNull(contextBrand);
            Assert.True(brand.BrandID == contextBrand.BrandID);
        }

        [Fact]
        public void Add_Brand()
        {
            // ARRANGE: Making the new brand.
            IBrand newBrand = new BrandDTO
            {
                Name = "Addidas"
            };
            bool success = false;
            Brand contextBrand = null;

            // ACT: Starting by adding a Brand through your service and then searching for it in the Context.
            success = service.Brand.AddAsync(newBrand).Result;

            using (var context = new WebshopContext())
            {
                contextBrand = context.Set<Brand>()
                    .SingleOrDefault(b => b.Name == "Addidas");
            }

            // ASSERT: Checking that the contextBrand is NotNull and then ensuring that success and contextBrand.Name is equals.
            Assert.NotNull(contextBrand);
            Assert.True(success && contextBrand.Name == "Addidas");
        }

        [Fact]
        public void Update_Brand()
        {
            // ARRANGE: Changing the name in a Brand.
            IBrand updatedBrand = new BrandDTO
            {
                BrandID = 1,
                Name = "Updated Name"
            };
            bool success = false;
            Brand contextBrand = null;

            // ACT: Updating a Brand through WebshopService and then we're finding one with the same Brand.Name in WebshopContext.
            success = service.Brand.UpdateAsync(updatedBrand).Result;

            using (var context = new WebshopContext())
            {
                contextBrand = context.Set<Brand>()
                    .SingleOrDefault(b => b.Name == "Updated Name");
            }

            // ASSERT: Checking that the contextBrand is NotNull and then making sure the Brand.Name is equals.
            Assert.NotNull(contextBrand);
            Assert.True(success && contextBrand.Name == "Updated Name");
        }

        [Fact]
        public void Remove_Brand()
        {
            // ARRANGE: Setting up the Brand you want to remove.
            IBrand removedBrand = new BrandDTO
            {
                BrandID = 1,
                Name = "Removed"
            };
            bool success = false;
            Brand contextBrand = null;

            // ACT: Removing the brand through the Service, then checking to make sure there isn't any Brand.Name with "string" in context.
            success = service.Brand.RemoveAsync(removedBrand).Result;

            using (var context = new WebshopContext())
            {
                contextBrand = context.Set<Brand>()
                    .SingleOrDefault(b => b.Name == "Removed");
            }

            // ASSERT: Checking that the contextBrand is still Null after searching, then checking that success has changed to True.
            Assert.Null(contextBrand);
            Assert.True(success);
        }
    }
}
