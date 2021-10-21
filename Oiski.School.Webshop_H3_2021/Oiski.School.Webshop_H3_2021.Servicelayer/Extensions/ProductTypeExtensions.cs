using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Extensions
{
    public static class ProductTypeExtensions
    {
        public static IQueryable<ProductTypeDTO> MapToBaseDTO(this IQueryable<ProductType> _productType)
        {
            return _productType
                .Select(
                pt => new ProductTypeDTO
                {
                    Product = pt.Product.MapSingleToBaseDTO(),
                    ProductID = pt.ProductID,
                    Type = pt.Type.MapSingleToBaseDTO(),
                    TypeID = pt.TypeID
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
    }
}
