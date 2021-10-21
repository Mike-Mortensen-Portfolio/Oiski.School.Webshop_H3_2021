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
                    ProductID = pt.ProductID,
                    Type = pt.Type.MapSingleToBaseDTO(),
                    TypeID = pt.TypeID
                });
        }

        public static ProductTypeDTO MapSingleToBaseDTO(this ProductType _productType)
        {
            return new ProductTypeDTO
            {
                ProductID = _productType.ProductID,
                Type = _productType.Type.MapSingleToBaseDTO(),
                TypeID = _productType.TypeID
            };
        }

        public static ICollection<ProductTypeDTO> ConvertToDTOList(this ICollection<ProductType> _productType)
        {
            return _productType
                .Select(pt => new ProductTypeDTO
                {
                    ProductID = pt.ProductID,
                    Type = pt.Type.MapSingleToBaseDTO(),
                    TypeID = pt.TypeID
                })
                .ToList();
        }
    }
}
