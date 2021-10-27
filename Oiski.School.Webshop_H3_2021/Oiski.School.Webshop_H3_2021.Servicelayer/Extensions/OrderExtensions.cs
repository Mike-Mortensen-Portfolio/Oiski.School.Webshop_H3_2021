using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public static class OrderExtensions
    {
        internal static IOrder MapToPublic(this Order _order)
        {
            return new OrderDTO
            {
                TypeOfDelivery = (IOrder.DeliveryType)_order.TypeOfDelivery,
                TypeOfPayment = (IOrder.PaymentMethod)_order.TypeOfPayment,
                CustomerID = _order.CustomerID,
                OrderDate = _order.OrderDate,
                OrderID = _order.OrderID
            };
        }
        internal static Order MapToInternal(this IOrder _order)
        {
            return new Order
            {
                TypeOfDelivery = (Order.DeliveryType)_order.TypeOfDelivery,
                TypeOfPayment = (Order.PaymentMethod)_order.TypeOfPayment,
                CustomerID = _order.CustomerID,
                OrderDate = _order.OrderDate,
                OrderID = _order.OrderID
            };
        }

        internal static IQueryable<IOrder> MapToPublic(this IQueryable<Order> _orders)
        {
            return _orders.Select(o => new OrderDTO
            {
                CustomerID = o.CustomerID,
                OrderDate = o.OrderDate,
                OrderID = o.OrderID,
                TypeOfDelivery = (IOrder.DeliveryType)o.TypeOfDelivery,
                TypeOfPayment = (IOrder.PaymentMethod)o.TypeOfPayment
            });
        }
        internal static IQueryable<Order> MapToInternal(this IQueryable<IOrder> _orders)
        {
            return _orders.Select(o => new Order
            {
                CustomerID = o.CustomerID,
                OrderDate = o.OrderDate,
                OrderID = o.OrderID,
                TypeOfDelivery = (Order.DeliveryType)o.TypeOfDelivery,
                TypeOfPayment = (Order.PaymentMethod)o.TypeOfPayment
            });
        }

        public static async Task<IReadOnlyList<IOrderProduct>> GetProductsAsync(this IOrder _order)
        {
            throw new NotImplementedException();
        }
        public static async Task<ICustomer> GetCustomerAsync(this IOrder _order)
        {
            throw new NotImplementedException();
        }
    }
}
