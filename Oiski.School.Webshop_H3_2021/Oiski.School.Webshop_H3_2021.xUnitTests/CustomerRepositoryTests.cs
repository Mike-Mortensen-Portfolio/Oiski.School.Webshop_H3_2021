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
    public class CustomerRepositoryTests
    {
        public CustomerRepositoryTests()
        {
            using (var context = new WebshopContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            service = new WebshopService();
        }

        private readonly IWebshopService service;

        [Fact]
        public void Get_All_Customers()
        {
            //  ARRANGE: Setting up containers
            IReadOnlyList<ICustomer> customers;
            IReadOnlyList<Customer> contextCustomers;

            //  ACT: Getting all customers from service and from DB context
            customers = service.Customer.GetAllAsync().Result;

            using (var context = new WebshopContext())
            {
                contextCustomers = context.Customers.ToList();
            }

            //  ASSERT: Validating that custemers isn't null and that the retrieved amount of data match
            Assert.NotNull(customers);
            Assert.True(customers.Count == contextCustomers.Count);
        }

        [Fact]
        public void Get_Customer_By_ID()
        {
            //  ARRANGE: setting up data containers
            ICustomer customer;
            Customer contextCustomer;

            //  ACT:
            customer = service.Customer.GetByIDAsync(1).Result;

            using (var context = new WebshopContext())
            {
                contextCustomer = context.Customers.SingleOrDefault(c => c.CustomerID == 1);
            }

            //  ASSERT:
            Assert.NotNull(customer);
            Assert.True(customer.FirstName == contextCustomer.FirstName);
        }

        [Fact]
        public void Get_Customer_By_Email()
        {
            //  ARRANGE: Setting up data containers
            ICustomer customer;
            Customer contextCustomer;

            //  ACT: Get customer through service and through DB context
            customer = service.Customer.GetByEmailAsync("Zhakalen@Gmail.com").Result;

            using (var context = new WebshopContext())
            {
                contextCustomer = context.Customers.SingleOrDefault(c => c.Email == "Zhakalen@Gmail.com");
            }

            //  ASSERT: Validate that customer isn't null and compare and validate that first name of customer and contextCustomer match
            Assert.NotNull(customer);
            Assert.True(customer.FirstName == contextCustomer.FirstName);
        }

        [Theory]
        [InlineData("MyWay", "MyCountry", "My@Mail.com", "MyName", "MyLastName", "12345678", 4444)]
        [InlineData("The way of mine", "The country of mine", "TheEmail@OfMine.com", "TheNameOfMine", "TheLastNameOfMine", "87654321", 8888)]
        public void Add_Customer(string _address, string _country, string _email, string _firstName, string _lastName, string _phone, int _zipCode)
        {
            //  ARRANGE: Setting up the instance to be added
            ICustomer customer = new CustomerDTO
            {
                Address = _address,
                Country = _country,
                Email = _email,
                FirstName = _firstName,
                LastName = _lastName,
                PhoneNumber = _phone,
                ZipCode = _zipCode,
            };
            Customer contextCustomer;

            //  ACT: Pushing data to DB and fetching the same data through DB Context
            bool success = service.Customer.AddAsync(customer).Result;

            using (var context = new WebshopContext())
            {
                contextCustomer = context.Customers.SingleOrDefault(c => c.Email == _email);
            }

            //  ASSERT: Validating that DB COntext can find the data and that the add method retuned true
            Assert.NotNull(contextCustomer);
            Assert.True(success);
        }

        [Fact]
        public void Update_Customer()
        {
            //  ARRANGE: Setting up customer to update
            CustomerDTO customer;
            Customer contextCustomer;
            using (var context = new WebshopContext())
            {
                customer = context.Customers
                    .Select(c => new CustomerDTO
                    {
                        Address = c.Address,
                        Country = c.Country,
                        CustomerID = c.CustomerID,
                        Email = c.Email,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        PhoneNumber = c.PhoneNumber,
                        UserID = c.UserID,
                        ZipCode = c.ZipCode
                    })
                    .FirstOrDefault();
            }

            //  ACT: Changing email of customer and updating the entity in DB
            customer.Email = "My@Mail.com";
            bool success = service.Customer.UpdateAsync(customer).Result;

            using (var context = new WebshopContext())
            {
                contextCustomer = context.Customers.SingleOrDefault(c => c.Email == "My@Mail.com");
            }

            //  ASSERT: Validating that the customer was in fact added and that the update method returned true as expected
            Assert.NotNull(contextCustomer);
            Assert.True(success);
        }

        [Fact]
        public void Remove_Customer()
        {
            //  ARRANGE: Setting up customer to remove
            CustomerDTO customer;
            Customer contextCustomer;
            using (var context = new WebshopContext())
            {
                customer = context.Customers
                    .Select(c => new CustomerDTO
                    {
                        Address = c.Address,
                        Country = c.Country,
                        CustomerID = c.CustomerID,
                        Email = c.Email,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        PhoneNumber = c.PhoneNumber,
                        UserID = c.UserID,
                        ZipCode = c.ZipCode
                    })
                    .FirstOrDefault();
            }

            //  ACT: Removing the entity from DB
            bool success = service.Customer.RemoveAsync(customer).Result;

            using (var context = new WebshopContext())
            {
                contextCustomer = context.Customers.SingleOrDefault(c => c.Email == customer.Email);
            }

            //  ASSERT: Validating that the customer was in fact added and that the remove method returned true as expected
            Assert.Null(contextCustomer);
            Assert.True(success);
        }

        [Fact]
        public void Get_Login_From_Customer()
        {
            //  ARRANGE: Setting up the customer from DB
            IUser user;
            ICustomer customer;
            using (var context = new WebshopContext())
            {
                customer = context.Customers
                    .Where(c => c.UserID != null)
                    .Select(c => new CustomerDTO
                    {
                        Address = c.Address,
                        Country = c.Country,
                        CustomerID = c.CustomerID,
                        Email = c.Email,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        PhoneNumber = c.PhoneNumber,
                        UserID = c.UserID,
                        ZipCode = c.ZipCode
                    })
                    .FirstOrDefault();
            }

            //  ACT: Fetching the login information
            user = customer.GetLoginAsync().Result;

            //  ASSERT: Verify that the login information isn't null
            Assert.NotNull(user);
        }
    }
}
