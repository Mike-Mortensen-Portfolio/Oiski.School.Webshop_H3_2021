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
        public static IQueryable<OrderDTO> MapToBaseDTO(this IQueryable<Order> _orders)
        {
            return _orders
                .Include(o => o.Products)
                .Select(
                o => new OrderDTO
                {
                    Customer = o.Customer,
                    CustomerID = o.CustomerID,
                    OrderDate = o.OrderDate,
                    OrderID = o.OrderID,
                    Products = o.Products
                });
        }
    }
}
