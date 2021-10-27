using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public static class OrderProductExtensions
    {
        internal static IOrderProduct MapToPublic(this OrderProduct _orderProduct)
        {
            if (_orderProduct == null) throw new ArgumentNullException(nameof(_orderProduct), "Cannot map NULL value");

            return new OrderProductDTO
            {
                OrderID = _orderProduct.OrderID,
                ProductID = _orderProduct.ProductID,
                Quantity = _orderProduct.Quantity
            };
        }
        internal static OrderProduct MapToInternal(this IOrderProduct _orderProduct)
        {
            if (_orderProduct == null) throw new ArgumentNullException(nameof(_orderProduct), "Cannot map NULL value");

            return new OrderProduct
            {
                OrderID = _orderProduct.OrderID,
                ProductID = _orderProduct.ProductID,
                Quantity = _orderProduct.Quantity
            };
        }

        internal static IQueryable<IOrderProduct> MapToPublic(this IQueryable<OrderProduct> _orderProducts)
        {
            if (_orderProducts == null) throw new ArgumentNullException(nameof(_orderProducts), "Cannot map NULL value");

            return _orderProducts.Select(op => new OrderProductDTO
            {
                OrderID = op.OrderID,
                ProductID = op.ProductID,
                Quantity = op.Quantity
            });
        }
        internal static IQueryable<OrderProduct> MapToInternal(this IQueryable<IOrderProduct> _orderproducts)
        {
            if (_orderproducts == null) throw new ArgumentNullException(nameof(_orderproducts), "Cannot map NULL value");

            return _orderproducts.Select(op => new OrderProduct
            {
                OrderID = op.OrderID,
                ProductID = op.ProductID,
                Quantity = op.Quantity
            });
        }

        public static async Task<IProduct> GetProductAsync(this IOrderProduct _orderProduct)
        {
            if (_orderProduct == null) throw new ArgumentNullException(nameof(_orderProduct), "Cannot map NULL value");

            return await new WebshopService().Product.GetByIDAsync(_orderProduct.ProductID);
        }

        public static async Task<IOrder> GetOrderAsync(this IOrderProduct _orderProduct)
        {
            if (_orderProduct == null) throw new ArgumentNullException(nameof(_orderProduct), "Cannot map NULL value");

            return await new WebshopService().Order.GetByIDAsync(_orderProduct.ProductID);
        }
    }
}
