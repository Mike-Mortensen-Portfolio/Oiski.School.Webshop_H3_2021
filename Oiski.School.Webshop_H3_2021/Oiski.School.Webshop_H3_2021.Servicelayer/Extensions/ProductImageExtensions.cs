using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public static class ProductImageExtensions
    {
        internal static IProductImage MapToPublic(this ProductImage _productImage)
        {
            if (_productImage == null) throw new ArgumentNullException(nameof(_productImage), "Cannot map NULL value");

            return new ProductImageDTO
            {
                ImageURL = _productImage.ImageURL,
                ProductID = _productImage.ProductID,
                ProductImageID = _productImage.ProductImageID,
                Title = _productImage.Title
            };
        }
        internal static ProductImage MapToInternal(this IProductImage _productImage)
        {
            if (_productImage == null) throw new ArgumentNullException(nameof(_productImage), "Cannot map NULL value");

            return new ProductImage
            {
                ImageURL = _productImage.ImageURL,
                ProductID = _productImage.ProductID,
                ProductImageID = _productImage.ProductImageID,
                Title = _productImage.Title
            };
        }
    }
}
