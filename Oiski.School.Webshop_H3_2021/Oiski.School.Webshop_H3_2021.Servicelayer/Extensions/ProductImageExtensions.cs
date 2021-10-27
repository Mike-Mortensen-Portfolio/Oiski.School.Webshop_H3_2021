using Oiski.School.Webshop_H3_2021.Datalayer.Entities;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public static class ProductImageExtensions
    {
        internal static IProductImage MapToPublic(this ProductImage _productImage)
        {
            return new ProductImageDTO
            {
                ImageURL = _productImage.ImageURL,
                ProductID = _productImage.ProductID,
                ProductImageID = _productImage.ProductImageID
            };
        }
        internal static ProductImage MapToInternal(this IProductImage _productImage)
        {
            return new ProductImage
            {
                ImageURL = _productImage.ImageURL,
                ProductID = _productImage.ProductID,
                ProductImageID = _productImage.ProductImageID
            };
        }
    }
}
