using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Oiski.School.Webshop_H3_2021.Servicelayer;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using static Oiski.School.Webshop_H3_2021.Servicelayer.IOrder;

namespace Oiski.School.Webshop_H3_2021.xUnitTests
{
    public class OrderRepositoryTests
    {
        public OrderRepositoryTests()
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
        public void Get_All_Orders()
        {
            // ARRANGE:
            int contextCount;

            // ACT: Get all Order through WebshopService and then all Orders through WebshopContext.
            int count = service.Order.GetAllAsync()
                .GetAwaiter()
                .GetResult()
                .Count;

            using (var context = new WebshopContext())
            {
                contextCount = context.Orders
                    .Count();
            }

            // ASSERT: Compare the amount on both the WebshopService and WebshopContext.
            Assert.True(count == contextCount);
        }

        [Fact]
        public void Get_Order_By_ID()
        {
            // ARRANGE:
            int searchID = 2;
            Order contextOrder = null;

            // ACT: Retrieving a Order on the WebshopService and then on the WebshopContext.
            IOrder order = service.Order.GetByIDAsync(searchID)
                .GetAwaiter()
                .GetResult();

            using (var context = new WebshopContext())
            {
                contextOrder = context.Orders
                    .SingleOrDefault(p => p.OrderID == searchID);
            }

            // ASSERT: Making sure the Order we retrieve on the WebshopContext isn't Null, then comparing the OrderID on the Service and DBContext.
            Assert.NotNull(order);
            Assert.True(order.OrderID == contextOrder.OrderID);
        }

        [Fact]
        public void Get_Order_By_Customer()
        {
            // ARRANGE:
            int customerID = 1;
            int contextCount;

            // ACT: Get all Orders with the same CategoryID through WebshopService and then through WebshopContext.
            int count = service.Order.GetByCustomerAsync(customerID)
                .GetAwaiter()
                .GetResult()
                .Count;

            using (var context = new WebshopContext())
            {
                contextCount = context.Orders
                    .Where(o => o.CustomerID == customerID)
                    .Count();
            }

            // ASSERT: Compare the amount on both the WebshopService and WebshopContext where it finds the same CustomerID.
            Assert.True(count == contextCount);
        }

        [Fact]
        public void Get_Order_By_Paymentmethod()
        {
            // ARRANGE:
            PaymentMethod paymentMethod = PaymentMethod.VISA;
            Order.PaymentMethod paymentMethod1 = Order.PaymentMethod.VISA;
            int serviceCount;
            int contextCount;

            // ACT: Getting all Orders with the same Paymentmethod on WebshopService and WebshopContext.
            serviceCount = service.Order.GetByPaymentMethodAsync(paymentMethod)
                .GetAwaiter()
                .GetResult()
                .Count;

            using (var context = new WebshopContext())
            {
                contextCount = context.Orders
                    .Where(o => o.TypeOfPayment == paymentMethod1)
                    .Count();
            }

            // ASSERT: Comparing the counts to be equal with one another.
            Assert.True(serviceCount == contextCount);
        }

        [Fact]
        public void Get_Order_By_DeliveryType()
        {
            // ARRANGE:
            DeliveryType deliveryType = DeliveryType.PostNord;
            Order.DeliveryType deliveryType1 = Order.DeliveryType.PostNord;
            int serviceCount;
            int contextCount;

            // ACT: Getting all Orders with the same DeliveryType on WebshopService and WebshopContext.
            serviceCount = service.Order.GetByDeliveryTypeAsync(deliveryType)
                .GetAwaiter()
                .GetResult()
                .Count;

            using (var context = new WebshopContext())
            {
                contextCount = context.Orders
                    .Where(o => o.TypeOfDelivery == deliveryType1)
                    .Count();
            }

            // ASSERT: Comparing the counts to be equal with one another.
            Assert.True(serviceCount == contextCount);
        }

        [Fact]
        public void Add_Order()
        {
            // ARRANGE: Creating a new Order to push up.
            IOrder newOrder = new OrderDTO
            {
                CustomerID = 1,
                OrderDate = DateTime.Now,
                TypeOfDelivery = DeliveryType.GLS,
                TypeOfPayment = PaymentMethod.Mastercard
            };
            bool success = false;
            Order.PaymentMethod paymentMethod = Order.PaymentMethod.Mastercard;
            Order contextOrder = null;

            // ACT: Adding the new Order through our Service, then finding it through the Context.
            success = service.Order.AddAsync(newOrder).Result;

            using (var context = new WebshopContext())
            {
                contextOrder = context.Orders
                    .SingleOrDefault(o => o.TypeOfPayment == paymentMethod);
            }

            // ASSERT: Checking if the Order found in Context is Null or not, then comparing to check if the success and the contextOrder.CustomerID are equals.
            Assert.NotNull(contextOrder);
            Assert.True(success && contextOrder.CustomerID == 1);
        }

        [Fact]
        public void Update_Order()
        {
            // ARRANGE: Creating a new Order where we set the OrderID on the Order we wanna Update.
            IOrder updatedOrder = new OrderDTO
            {
                OrderID = 1,
                CustomerID = 1,
                OrderDate = DateTime.Now,
                TypeOfDelivery = DeliveryType.DAO
            };
            bool success = false;
            Order.DeliveryType deliveryType = Order.DeliveryType.DAO;
            Order contextOrder = null;

            // ACT: Updating the new Order through our Service, then finding it through the Context.
            success = service.Order.UpdateAsync(updatedOrder).Result;

            using (var context = new WebshopContext())
            {
                contextOrder = context.Orders
                    .SingleOrDefault(o => o.TypeOfDelivery == deliveryType);
            }

            // ASSERT: Checking if the Order found in Context is Null or not, then comparing to check if the success and the contextOrder.CustomerID are equals.
            Assert.NotNull(contextOrder);
            Assert.True(success && contextOrder.CustomerID == 1);
        }

        [Fact]
        public void Remove_Order()
        {
            // ARRANGE: Creating a new Order where we set the OrderID on the Order we wanna Update.
            IOrder deletedOrder = new OrderDTO
            {
                OrderID = 1,
            };
            bool success = false;
            Order contextOrder = null;

            // ACT: Removing the new Order through our Service, then trying finding it through the Context.
            success = service.Order.RemoveAsync(deletedOrder).Result;

            using (var context = new WebshopContext())
            {
                contextOrder = context.Orders
                    .SingleOrDefault(o => o.OrderID == 1);
            }

            // ASSERT: Checking if the Product is Null/Not in Context, then checking if our success has become true when Removing the Order.
            Assert.Null(contextOrder);
            Assert.True(success);
        }

        [Fact]
        public void Get_Customer_Extension()
        {
            // ARRANGE:            
            IOrder order = null;
            using (var context = new WebshopContext())
            {
                order = context.Orders
                    .Select(o => new OrderDTO
                    {
                        CustomerID = o.CustomerID,
                        OrderDate = o.OrderDate,
                        OrderID = o.OrderID,
                        TypeOfDelivery = (DeliveryType)o.TypeOfDelivery,
                        TypeOfPayment = (PaymentMethod)o.TypeOfPayment

                    }).FirstOrDefault();
            }

            // ACT: Getting the Customer based on the Order we got from ARRANGE.
            ICustomer customer = order.GetCustomerAsync().Result;

            // ASSET: Checking the customer isn't Null.
            Assert.NotNull(customer);
        }

        [Fact]
        public void Get_Products_Extension()
        {
            // ARRANGE:
            IOrder order = null;
            IReadOnlyList<IOrderProduct> products = null;
            using (var context = new WebshopContext())
            {
                order = context.Orders
                    .Select(o => new OrderDTO
                    {
                        CustomerID = o.CustomerID,
                        OrderDate = o.OrderDate,
                        OrderID = o.OrderID,
                        TypeOfDelivery = (DeliveryType)o.TypeOfDelivery,
                        TypeOfPayment = (PaymentMethod)o.TypeOfPayment

                    }).FirstOrDefault();
            }

            // ACT: Getting all of the products existing in the above Order from the WebshopContext.
            products = order.GetProductsAsync().Result;

            // ASSERT: Checking that the IReadOnlyList<IOrderProduct> isn't Null.
            Assert.NotNull(products);
        }
    }
}
