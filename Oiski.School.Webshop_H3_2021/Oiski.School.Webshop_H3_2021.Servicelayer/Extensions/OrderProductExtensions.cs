using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Extensions
{
    public static class OrderProductExtensions
    {
        internal static IOrderProduct MapToPublic(this OrderProduct _orderProduct)
        {
            return new OrderProductDTO
            {
                OrderID = _orderProduct.OrderID,
                ProductID = _orderProduct.ProductID,
                Quantity = _orderProduct.Quantity
            };
        }
        internal static OrderProduct MapToInternal(this IOrderProduct _orderProduct)
        {
            return new OrderProduct
            {
                OrderID = _orderProduct.OrderID,
                ProductID = _orderProduct.ProductID,
                Quantity = _orderProduct.Quantity
            };
        }

        public static async Task<IProduct> GetProductAsync(this IOrderProduct _orderProduct)
        {
            throw new NotImplementedException();
        }

        public static async Task<IOrder> GetOrderAsync(this IOrderProduct _orderProduct)
        {
            throw new NotImplementedException();
        }
    }
}
