using Microsoft.EntityFrameworkCore;
using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;
using System.Linq;
using Xunit;

namespace Oiski.School.Webshop_H3_2021.UnitTests
{
    public class WebshopTestsInMemory
    {
        [Fact]
        public void Add_Writes_To_DB()
        {
            //  Arrange: Configure context options
            var options = new DbContextOptionsBuilder<WebshopContext>()
                .UseInMemoryDatabase("Add_Writes_To_DB")
                .Options;

            //  Arrange: Store initial DB customer count
            int initialCustomerCount;

            //  Act: Test the add function
            using (var context = new WebshopContext(options))
            {
                initialCustomerCount = context.Customers.Count();

                WebshopService.Access.SetContext(context);

                WebshopService.Access.Add(new Customer() { Address = "MyAddress" });
            }

            //  Assert: Compare the service result against a context result
            using (var context = new WebshopContext(options))
            {
                int count = context.Customers.Count();

                Assert.Equal(initialCustomerCount + 1, count);
                Assert.Equal("MyAddress", context.Customers.Where(c => c.Address == "MyAddress").Single().Address);
            }
        }

        [Fact]
        public void Update_Customer_Name_In_DB()
        {
            //  Arrange: Configure context options
            var options = new DbContextOptionsBuilder<WebshopContext>()
                .UseInMemoryDatabase("Add_Writes_To_DB")
                .Options;

            //  Arrange: Insert data to update on
            using (var context = new WebshopContext(options))
            {
                context.Customers.Add(new Customer { FirstName = "Hansi" });
                context.SaveChanges();
            }

            //  Act: Update customer name
            using (var context = new WebshopContext(options))
            {
                WebshopService.Access.SetContext(context);

                var customer = context.Customers.FirstOrDefault();

                customer.FirstName = "Laila";

                WebshopService.Access.Update(customer);
            }

            //  Assert: Validate that the data was updated correctly
            using (var context = new WebshopContext(options))
            {
                //Assert.Single(context.Customers);
                Assert.True((context.Customers.Where(c => c.FirstName == "Laila").Single().FirstName == "Laila"));
            }
        }

        [Fact]
        public void Delete_Customer_From_DB()
        {
            //  Arrange: Configure context options
            var options = new DbContextOptionsBuilder<WebshopContext>()
                .UseInMemoryDatabase("Add_Writes_To_DB")
                .Options;

            // Arrange: ID to compare against
            int? customerID = null;

            // Arrange: Insert data to be deleted and get the ID for it
            using (var context = new WebshopContext(options))
            {
                context.Customers.Add(new Customer { FirstName = "Yela" });
                context.SaveChanges();

                customerID = context.Customers.FirstOrDefault().CustomerID;
            }

            //  Act: Delete data
            using (var context = new WebshopContext(options))
            {
                WebshopService.Access.SetContext(context);

                var customer = context.Customers.FirstOrDefault();

                WebshopService.Access.Remove(customer);
            }

            //  Assert: Validate that the data was deleted in DB
            using (var context = new WebshopContext(options))
            {
                var customer = context.Customers.Find(customerID);

                Assert.NotNull(customerID);
                Assert.Null(customer);
            }
        }

        [Fact]
        public void Find_Search_DB_For_Customer_With_Customer_Login_Included()
        {
            //  Arrange: Configure context options
            var options = new DbContextOptionsBuilder<WebshopContext>()
                .UseInMemoryDatabase("Add_Writes_To_DB")
                .Options;

            // Arrange: Insert data to find (We go through Customer to get to CustomerLogin)
            using (var context = new WebshopContext(options))
            {
                Customer customer = new Customer() { FirstName = "GingerbreadBoy" };
                customer.CustomerLogin = new CustomerLogin { };

                context.Customers.Add(customer);
                context.SaveChanges();
            }

            //  Act:
            using (var context = new WebshopContext(options))
            {
                WebshopService.Access.SetContext(context);

                Customer contextCustomer = context.Customers.Where(c => c.FirstName == "GingerbreadBoy")
                    .Include(c => c.CustomerLogin)
                    .FirstOrDefault();

                CustomerLogin login = contextCustomer.CustomerLogin;

                Customer customer = WebshopService.Access.Find<Customer>(c => c.FirstName == "GingerbreadBoy")
                    .Include(c => c.CustomerLogin)
                    .Single();

                Assert.NotNull(customer.CustomerLogin);
            }

            //Assert:
        }
    }
}
