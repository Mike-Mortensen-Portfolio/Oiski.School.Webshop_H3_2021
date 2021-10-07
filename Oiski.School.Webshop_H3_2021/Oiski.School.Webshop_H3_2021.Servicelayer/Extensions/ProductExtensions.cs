using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Extensions
{
    public static class ProductExtensions 
    {
        public static decimal PriceSum(this IQueryable<Product> _products)
        {
            return _products.Sum(p => p.Price);
        }
    }
}
