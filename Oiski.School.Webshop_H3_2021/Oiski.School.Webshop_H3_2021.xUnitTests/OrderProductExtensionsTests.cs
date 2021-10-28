using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using Oiski.School.Webshop_H3_2021.Servicelayer;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System.Linq;

namespace Oiski.School.Webshop_H3_2021.xUnitTests
{
    public class OrderProductExtensionsTests
    {
        public OrderProductExtensionsTests()
        {
            using (var context = new WebshopContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        [Fact]
        public void Get_Product_Extension()
        {
            //  ARRANGE: Setting up Orderproduct instance to perform on and getting the equalent OrderProduct from DB to compare against
            IOrderProduct oProduct;
            IProduct product;
            Product contextProduct;
            using (var context = new WebshopContext())
            {
                oProduct = context.Set<OrderProduct>()
                    .Select(op => new OrderProductDTO
                    {
                        OrderID = op.OrderID,
                        ProductID = op.ProductID,
                        Quantity = op.Quantity

                    }).FirstOrDefault();

                contextProduct = context.Products.SingleOrDefault(op => op.ProductID == oProduct.ProductID);
            }

            //  ACT: Execute extension
            product = oProduct.GetProductAsync().Result;

            // ASSERT: Veriy that product isn't null and that the correct product was collected
            Assert.NotNull(product);
            Assert.True(product.Title == contextProduct.Title);
        }

        [Fact]
        public void Get_Order_Extension()
        {
            //  ARRANGE: Setting up Orderproduct instance to perform on and getting the equalent OrderProduct from DB to compare against
            IOrderProduct oProduct;
            IOrder order;
            Order contextOrder;
            using (var context = new WebshopContext())
            {
                oProduct = context.Set<OrderProduct>()
                    .Select(op => new OrderProductDTO
                    {
                        OrderID = op.OrderID,
                        ProductID = op.ProductID,
                        Quantity = op.Quantity

                    }).FirstOrDefault();

                contextOrder = context.Orders.SingleOrDefault(o => o.OrderID == oProduct.OrderID);
            }

            //  ACT: Execute extension
            order = oProduct.GetOrderAsync().Result;

            // ASSERT: Veriy that order isn't null and that the correct order was collected
            Assert.NotNull(order);
            Assert.True(order.CustomerID == contextOrder.CustomerID);
        }
    }
}
