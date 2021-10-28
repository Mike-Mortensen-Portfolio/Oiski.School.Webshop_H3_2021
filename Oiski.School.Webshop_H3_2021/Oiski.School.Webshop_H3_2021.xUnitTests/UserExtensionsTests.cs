using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Oiski.School.Webshop_H3_2021.Servicelayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Oiski.School.Webshop_H3_2021.xUnitTests
{
    public class UserExtensionsTests
    {
        public UserExtensionsTests()
        {
            using (var context = new WebshopContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        [Fact]
        public void Get_Customer_Extension()
        {
            //  ASSERT:
            IUser user;
            ICustomer customer;
            using (var context = new WebshopContext())
            {
                user = context.Set<User>()
                    .Select(u => new UserDTO
                    {
                        IsAdmin = u.IsAdmin,
                        CustomerID = u.CustomerID,
                        Password = u.Password,
                        UserID = u.UserID
                    }).FirstOrDefault();
            }

            //  ACT:
            customer = user.GetCustomerAsync().Result;

            //  ASSERT:
            Assert.NotNull(customer);
        }

        [Fact]
        public void Get_Orders_Extensions()
        {
            //  ASSERT:
            IUser user;
            IReadOnlyList<IOrder> orders;
            IReadOnlyList<Order> contextOrders;
            using (var context = new WebshopContext())
            {
                user = context.Set<User>()
                    .Select(u => new UserDTO
                    {
                        IsAdmin = u.IsAdmin,
                        CustomerID = u.CustomerID,
                        Password = u.Password,
                        UserID = u.UserID
                    }).FirstOrDefault();
            }

            //  ACT:
            orders = user.GetOrderAsync().Result;

            using (var context = new WebshopContext())
            {
                contextOrders = context.Orders.Where(o => o.CustomerID == user.CustomerID)
                    .ToList();
            }

            //  ASSERT:
            Assert.NotNull(orders);
            Assert.True(orders.Count == contextOrders.Count);
        }
    }
}
