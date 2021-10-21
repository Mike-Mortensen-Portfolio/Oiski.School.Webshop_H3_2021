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

        /// <summary>
        /// Maps a collection of <see cref="Product"/> <see langword="objects"/> to an <see cref="IQueryable{T}"/> <see langword="object"/> of type <see cref="ProductDisplayDTO"/>
        /// </summary>
        /// <param name="_products"></param>
        /// <returns>The mapped <see cref="IQueryable{T}"/> of type <see cref="ProductDisplayDTO"/> if <paramref name="_products"/> is not <see langword="null"/>. Otherwise returns <see langword="null"/></returns>
        public static IQueryable<ProductDisplayDTO> MapToDisplayDTO(this IQueryable<Product> _products)
        {
            if (_products == null) return null;

            return _products
                .Select(p =>
          new ProductDisplayDTO
          {
              BrandName = p.BrandName,
              Description = p.Description,
              InStock = p.InStock,
              Price = p.Price,
              ProductID = p.ProductID,
              ProductImages = p.ProductImages.ConvertToDTOList(),
              DisplayImage = p.ProductImages.FirstOrDefault().ImageURL,
              Title = p.Title,
              Types = p.Types.ConvertToDTOList()
          });
        }

        /// <summary>
        /// Maps a collection of <see cref="Product"/> <see langword="objects"/> to an <see cref="IQueryable{T}"/> <see langword="object"/> of type <see cref="ProductDTO"/>
        /// </summary>
        /// <param name="_products"></param>
        /// <returns>The mapped <see cref="IQueryable{T}"/> of type <see cref="ProductDTO"/> if <paramref name="_products"/> is not <see langword="null"/>. Otherwise returns <see langword="null"/></returns>
        public static IQueryable<ProductDTO> MapToBaseDTO(this IQueryable<Product> _products)
        {
            if (_products == null) return null;

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
                  ProductImages = p.ProductImages.ConvertToDTOList(),
                  Title = p.Title,
                  Types = p.Types.ConvertToDTOList()
              });
        }

        /// <summary>
        /// Maps all properties <paramref name="_product"/> to a <see cref="ProductDTO"/>
        /// </summary>
        /// <param name="_product"></param>
        /// <returns>The mapped <see cref="ProductDTO"/> if <paramref name="_productType"/> is not <see langword="null"/>. Otherwise returns <see langword="null"/></returns>
        public static ProductDTO MapSingleToBaseDTO(this Product _product)
        {
            if (_product == null) return null;

            return new ProductDTO
            {
                BrandName = _product.BrandName,
                Description = _product.Description,
                InStock = _product.InStock,
                Price = _product.Price,
                ProductID = _product.ProductID,
                ProductImages = _product.ProductImages.ConvertToDTOList(),
                Title = _product.Title,
                Types = _product.Types.ConvertToDTOList()
            };
        }
    }
}
