using Microsoft.EntityFrameworkCore;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Extensions
{
    public static class OrderExtensions
    {
        /// <summary>
        /// Maps a collection of <see cref="Order"/> <see langword="objects"/> to an <see cref="IQueryable{T}"/> <see langword="object"/> of type <see cref="OrderDTO"/>
        /// </summary>
        /// <param name="_orders"></param>
        /// <returns>The mapped <see cref="IQueryable{T}"/> of type <see cref="OrderDTO"/> if <paramref name="_orders"/> is not <see langword="null"/>. Otherwise returns <see langword="null"/></returns>
        public static IQueryable<OrderDTO> MapToBaseDTO(this IQueryable<Order> _orders)
        {
            if (_orders == null) return null;

            return _orders
                .Include(o => o.Products)
                .Select(
                o => new OrderDTO
                {
                    Customer = o.Customer.MapSingleToBaseDTO(),
                    CustomerID = o.CustomerID,
                    OrderDate = o.OrderDate,
                    OrderID = o.OrderID,
                    Products = o.Products.ConvertToDTOList()
                });
        }

        /// <summary>
        /// Maps all properties of <paramref name="_order"/> to an <see cref="OrderDTO"/>
        /// </summary>
        /// <param name="_order"></param>
        /// <returns>The mapped <see cref="ProductImageDTO"/> if <paramref name="_order"/> is not <see langword="null"/>. Otherwise returns <see langword="null"/></returns>
        public static OrderDTO MapSingleToBaseDTO(this Order _order)
        {
            if (_order == null) return null;

            return new OrderDTO
            {
                Customer = _order.Customer.MapSingleToBaseDTO(),
                CustomerID = _order.CustomerID,
                OrderDate = _order.OrderDate,
                Products = _order.Products.ConvertToDTOList()
            };
        }

        /// <summary>
        /// Maps a collection of <see cref="Order"/> <see langword="objects"/> to an <see cref="IQueryable{T}"/> <see langword="object"/> of type <see cref="OrderDTO"/>
        /// </summary>
        /// <param name="_orders"></param>
        /// <returns>The mapped <see cref="IQueryable{T}"/> of type <see cref="OrderDTO"/> if <paramref name="_orders"/> is not <see langword="null"/>. Otherwise returns <see langword="null"/></returns>
        public static ICollection<OrderDTO> ConvertToDTOList(this ICollection<Order> _orders)
        {
            if (_orders == null) return null;

            return _orders
                .Select(o => new OrderDTO
                {
                    Customer = o.Customer.MapSingleToBaseDTO(),
                    CustomerID = o.CustomerID,
                    OrderDate = o.OrderDate,
                    OrderID = o.OrderID,
                    Products = o.Products.ConvertToDTOList()
                })
                .ToList();
        }
    }
}
