using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Extensions
{
    public static class ProductExtensions
    {
        internal static IProduct MapToPublic(this Product _product)
        {
            return new ProductDTO
            {
                BrandID = _product.BrandID,
                Description = _product.Description,
                InStock = _product.InStock,
                Price = _product.Price,
                ProductID = _product.ProductID,
                Title = _product.Title
            };
        }
        internal static Product MapToInternal(this IProduct _product)
        {
            return new Product
            {
                BrandID = _product.BrandID,
                Description = _product.Description,
                InStock = _product.InStock,
                Price = _product.Price,
                ProductID = _product.ProductID,
                Title = _product.Title
            };
        }

        public static async Task<IReadOnlyList<IOrder>> GetOrdersAsync(this IProduct _product)
        {
            throw new NotImplementedException();
        }

        public static async Task<IReadOnlyList<IProductImage>> GetImagesAsync(this IProduct _product)
        {
            throw new NotImplementedException();
        }
        public static async Task<ICategory> GetCategoryAsync(this IProduct _product)
        {
            throw new NotImplementedException();
        }
        public static async Task<IBrand> GetBrandAsync(this IProduct _product)
        {
            throw new NotImplementedException();
        }
    }
}
