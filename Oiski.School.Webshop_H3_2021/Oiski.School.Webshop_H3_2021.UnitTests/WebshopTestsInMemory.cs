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

                var service = new WebshopService(context);

                service.Add(new Customer() { Address = "MyAddress" });
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
                .UseInMemoryDatabase("Update_Customer_Name_In_DB")
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
                var service = new WebshopService(context);

                var customer = context.Customers.FirstOrDefault();

                customer.FirstName = "Laila";

                service.Update(customer);
            }

            //  Assert: Validate that the data was updated correctly
            using (var context = new WebshopContext(options))
            {
                Assert.True((context.Customers.Where(c => c.FirstName == "Laila").Single().FirstName == "Laila"));
            }
        }

        [Fact]
        public void Delete_Customer_From_DB()
        {
            //  Arrange: Configure context options
            var options = new DbContextOptionsBuilder<WebshopContext>()
                .UseInMemoryDatabase("Delete_Customer_From_DB")
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
                var service = new WebshopService(context);

                var customer = context.Customers.FirstOrDefault();

                service.Remove(customer);
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
                .UseInMemoryDatabase("Find_Search_DB_For_Customer_With_Customer_Login_Included")
                .Options;

            //  Arrange: Result container
            Customer customer = null;

            // Arrange: Insert data to find (We go through Customer to get to CustomerLogin)
            using (var context = new WebshopContext(options))
            {
                Customer cust = new Customer() { FirstName = "GingerbreadBoy" };
                cust.User = new User { };

                context.Customers.Add(cust);
                context.SaveChanges();
            }

            //  Act:    Locate and extract customer data
            using (var context = new WebshopContext(options))
            {
                var service = new WebshopService(context);

                customer = service.GetQueryable<Customer>()
                   .Where(c => c.FirstName == "GingerbreadBoy")
                   .Include(c => c.User)
                   .Single();
            }

            //Assert:   //  Check if CustomerLogin data is null, and compare context query against our service query
            using (var context = new WebshopContext(options))
            {
                var service = new WebshopService(context);

                Customer contextCustomer = context.Customers.Where(c => c.FirstName == "GingerbreadBoy")
                    .Include(c => c.User)
                    .FirstOrDefault();

                User login = contextCustomer.User;

                Assert.NotNull(customer.User);
                Assert.True((customer.User.UserID == login.UserID));
            }

        }
    }
}
