using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Extensions
{
    public static class OrderProductExtensions
    {
        /// <summary>
        /// Maps a collection of <see cref="OrderProduct"/> <see langword="objects"/> to an <see cref="IQueryable{T}"/> <see langword="object"/> of type <see cref="OrderProductDTO"/>
        /// </summary>
        /// <param name="_orderProducts"></param>
        /// <returns>The mapped <see cref="IQueryable{T}"/> of type <see cref="OrderProductDTO"/> if <paramref name="_orderProducts"/> is not <see langword="null"/>. Otherwise returns <see langword="null"/></returns>
        public static IQueryable<OrderProductDTO> MapToBaseDTO(this IQueryable<OrderProduct> _orderProducts)
        {
            if (_orderProducts == null) return null;

            return _orderProducts
                .Select(op => new OrderProductDTO
                {
                    Order = op.Order.MapSingleToBaseDTO(),
                    Product = op.Product.MapSingleToBaseDTO(),
                    Quantity = op.Quantity
                });
        }

        /// <summary>
        /// Maps a collection of <see cref="OrderProduct"/> <see langword="objects"/> to an <see cref="IQueryable{T}"/> <see langword="object"/> of type <see cref="OrderProductDTO"/>
        /// </summary>
        /// <param name="_orderProducts"></param>
        /// <returns>The mapped <see cref="IQueryable{T}"/> of type <see cref="OrderProductDTO"/> if <paramref name="_types"/> is not <see langword="null"/>. Otherwise returns <see langword="null"/></returns>
        public static ICollection<OrderProductDTO> ConvertToDTOList(this ICollection<OrderProduct> _orderProducts)
        {
            if (_orderProducts == null) return null;

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
