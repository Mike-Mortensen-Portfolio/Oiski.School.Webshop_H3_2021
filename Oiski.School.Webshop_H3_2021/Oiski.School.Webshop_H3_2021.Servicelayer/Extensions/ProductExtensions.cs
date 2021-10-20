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
              DisplayImage = p.ProductImages.FirstOrDefault().ImageStream,
              Title = p.Title,
              Types = p.Types
          });
        }

        public static IQueryable<ProductDTO> MapToBaseDTO(this IQueryable<Product> _products)
        {
            return _products
                .Include(p => p.Types)
                .ThenInclude(pt => pt.Type)
                .Include(p => p.ProductImages)
                .Select(p =>
              new ProductDTO
              {
                  BrandName = p.BrandName,
                  Description = p.Description,
                  InStock = p.InStock,
                  Price = p.Price,
                  ProductID = p.ProductID,
                  ProductImages = p.ProductImages,
                  Title = p.Title,
                  Types = p.Types
              });
        }

        public static ProductDTO MapSingleToBaseDTO(this Product _product)
        {
            return new ProductDTO
            {
                BrandName = _product.BrandName,
                Description = _product.Description,
                InStock = _product.InStock,
                Price = _product.Price,
                ProductID = _product.ProductID,
                ProductImages = _product.ProductImages,
                Title = _product.Title,
                Types = _product.Types
            };
        }
    }
}
