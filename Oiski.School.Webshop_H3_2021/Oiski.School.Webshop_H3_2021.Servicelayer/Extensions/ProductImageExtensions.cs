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
        /// <summary>
        /// Maps a collection of <see cref="ProductImage"/> <see langword="objects"/> to an <see cref="IQueryable{T}"/> <see langword="object"/> of type <see cref="ProductImageDTO"/>
        /// </summary>
        /// <param name="_productImages"></param>
        /// <returns>The mapped <see cref="IQueryable{T}"/> of type <see cref="ProductImageDTO"/> if <paramref name="_productImages"/> is not <see langword="null"/>. Otherwise returns <see langword="null"/></returns>
        public static IQueryable<ProductImageDTO> MapToBaseDTO(this IQueryable<ProductImage> _productImages)
        {
            if (_productImages == null) return null;

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

        /// <summary>
        /// Maps all properties of <paramref name="_productImages"/> to a <see cref="ProductImageDTO"/>
        /// </summary>
        /// <param name="_productImages"></param>
        /// <returns>The mapped <see cref="ProductImageDTO"/> if <paramref name="_productType"/> is not <see langword="null"/>. Otherwise returns <see langword="null"/></returns>
        public static ProductImageDTO MapSingleToBaseDTO(this ProductImage _productImage)
        {
            if (_productImage == null) return null;

            return new ProductImageDTO
            {
                ImageURL = _productImage.ImageURL,
                ProductID = _productImage.ProductID,
                ProductImageID = _productImage.ProductImageID,
                Title = _productImage.Title
            };
        }

        /// <summary>
        /// Converts a collection of <see cref="ProductImage"/> <see langword="objects"/> to an <see cref="ICollection{T}{T}"/> <see langword="object"/> of type <see cref="ProductImageDTO"/>
        /// </summary>
        /// <param name="_productImages"></param>
        /// <returns>The mapped <see cref="ICollection{T}"/> of type <see cref="ProductImageDTO"/> if <paramref name="_productImages"/> is not <see langword="null"/>. Otherwise returns <see langword="null"/></returns>
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
