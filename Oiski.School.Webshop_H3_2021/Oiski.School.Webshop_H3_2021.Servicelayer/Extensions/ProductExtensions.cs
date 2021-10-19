using Microsoft.EntityFrameworkCore;
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

        public static IQueryable<ProductDisplayDTO> MapToDisplayDTO(this IQueryable<Product> _products)
        {
            return _products
                .Include(p => p.Types)
                .Select(p =>
          new ProductDisplayDTO
          {
              BrandName = p.BrandName,
              Description = p.Description,
              InStock = p.InStock,
              Price = p.Price,
              ProductID = p.ProductID,
              ProductImage = p.ProductImages.FirstOrDefault().ImageStream,
              Title = p.Title,
              Types = p.Types
          });
        }
    }
}
