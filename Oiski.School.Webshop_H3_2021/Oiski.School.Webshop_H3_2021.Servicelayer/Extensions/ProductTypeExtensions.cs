using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Extensions
{
    public static class ProductTypeExtensions
    {
        /// <summary>
        /// Maps a collection of <see cref="ProductType"/> <see langword="objects"/> to an <see cref="IQueryable{T}"/> <see langword="object"/> of type <see cref="ProductTypeDTO"/>
        /// </summary>
        /// <param name="_productType"></param>
        /// <returns>The mapped <see cref="IQueryable{T}"/> of type <see cref="ProductTypeDTO"/> if <paramref name="_productType"/> is not <see langword="null"/>. Otherwise returns <see langword="null"/></returns>
        public static IQueryable<ProductTypeDTO> MapToBaseDTO(this IQueryable<ProductType> _productType)
        {
            if (_productType == null) return null;

            return _productType
                .Select(
                pt => new ProductTypeDTO
                {
                    ProductID = pt.ProductID,
                    Type = pt.Type.MapSingleToBaseDTO(),
                    TypeID = pt.TypeID
                });
        }

        /// <summary>
        /// Maps all properties of <paramref name="_productType"/> to a <see cref="ProductTypeDTO"/>
        /// </summary>
        /// <param name="_productType"></param>
        /// <returns>The mapped <see cref="ProductTypeDTO"/> if <paramref name="_productType"/> is not <see langword="null"/>. Otherwise returns <see langword="null"/></returns>
        public static ProductTypeDTO MapSingleToBaseDTO(this ProductType _productType)
        {
            if (_productType == null) return null;

            return new ProductTypeDTO
            {
                ProductID = _productType.ProductID,
                Type = _productType.Type.MapSingleToBaseDTO(),
                TypeID = _productType.TypeID
            };
        }

        /// <summary>
        /// Converts a collection of <see cref="ProductType"/> <see langword="objects"/> to an <see cref="ICollection{T}{T}"/> <see langword="object"/> of type <see cref="ProductTypeDTO"/>
        /// </summary>
        /// <param name="_productType"></param>
        /// <returns>The mapped <see cref="ICollection{T}"/> of type <see cref="ProductTypeDTO"/> if <paramref name="_productType"/> is not <see langword="null"/>. Otherwise returns <see langword="null"/></returns>
        public static ICollection<ProductTypeDTO> ConvertToDTOList(this ICollection<ProductType> _productType)
        {
            if (_productType == null) return null;

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
