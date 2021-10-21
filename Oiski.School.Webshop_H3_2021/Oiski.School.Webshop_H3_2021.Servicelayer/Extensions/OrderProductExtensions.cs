using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Extensions
{
    public static class OrderProductExtensions
    {
        public static IQueryable<OrderProductDTO> MapToBaseDTO(this IQueryable<OrderProduct> _orderProducts)
        {
            return _orderProducts
                .Select(op => new OrderProductDTO
                {
                    Order = op.Order.MapSingleToBaseDTO(),
                    Product = op.Product.MapSingleToBaseDTO(),
                    Quantity = op.Quantity
                });
        }

        public static ICollection<OrderProductDTO> ConvertToDTOList(this ICollection<OrderProduct> _orderProducts)
        {
            return _orderProducts
                .Select(op => new OrderProductDTO
                {
                    Order = op.Order.MapSingleToBaseDTO(),
                    OrderID = op.OrderID,
                    Product = op.Product.MapSingleToBaseDTO(),
                    ProductID = op.ProductID,
                    Quantity = op.Quantity
                })
                .ToList();
        }
    }
}
