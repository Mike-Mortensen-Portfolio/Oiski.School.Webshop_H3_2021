using Microsoft.EntityFrameworkCore;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public static class ProductImageExtensions
    {
        public static IQueryable<ProductImageDTO> MapToBaseDTO(this IQueryable<ProductImage> _productImages)
        {
            return _productImages
                .Select(
                op => new ProductImageDTO
                {
                    ImageURL = op.ImageURL,
                    ProductID = op.ProductID,
                    ProductImageID = op.ProductImageID,
                    Title = op.Title
                });
        }

        public static ProductImageDTO MapSingleToBaseDTO(this ProductImage _productImage)
        {
            return new ProductImageDTO
            {
                ImageURL = _productImage.ImageURL,
                ProductID = _productImage.ProductID,
                ProductImageID = _productImage.ProductImageID,
                Title = _productImage.Title
            };
        }

        public static ICollection<ProductImageDTO> ConvertToDTOList(this ICollection<ProductImage> _productImages)
        {
            return _productImages
                .Select(pi => new ProductImageDTO
                {
                    ImageURL = pi.ImageURL,
                    ProductID = pi.ProductID,
                    ProductImageID = pi.ProductImageID,
                    Title = pi.Title
                })
                .ToList();
        }
    }
}
