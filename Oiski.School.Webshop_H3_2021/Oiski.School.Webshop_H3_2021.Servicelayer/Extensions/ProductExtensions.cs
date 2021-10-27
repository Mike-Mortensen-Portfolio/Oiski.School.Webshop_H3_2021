using Microsoft.EntityFrameworkCore;
using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public static class ProductExtensions
    {
        internal static IProduct MapToPublic(this Product _product)
        {
            if (_product == null) throw new ArgumentNullException(nameof(_product), "Cannot map NULL value");

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
            if (_product == null) throw new ArgumentNullException(nameof(_product), "Cannot map NULL value");

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

        internal static IQueryable<IProduct> MapToPublic(this IQueryable<Product> _products)
        {
            if (_products == null) throw new ArgumentNullException(nameof(_products), "Cannot map NULL value");

            return _products.Select(p => new ProductDTO
            {
                BrandID = p.BrandID,
                Description = p.Description,
                InStock = p.InStock,
                Price = p.Price,
                ProductID = p.ProductID,
                Title = p.Title
            });
        }
        internal static IQueryable<Product> MapToInternal(this IQueryable<IProduct> _products)
        {
            if (_products == null) throw new ArgumentNullException(nameof(_products), "Cannot map NULL value");

            return _products.Select(p => new Product
            {
                BrandID = p.BrandID,
                Description = p.Description,
                InStock = p.InStock,
                Price = p.Price,
                ProductID = p.ProductID,
                Title = p.Title
            });
        }

        public static async Task<IReadOnlyList<IOrder>> GetOrdersAsync(this IProduct _product)
        {
            if (_product == null) throw new ArgumentNullException(nameof(_product), "Cannot map NULL value");

            using (var context = new WebshopContext())
            {
                return await context.Set<OrderProduct>()
                .Where(op => op.ProductID == _product.ProductID)
                .Include(op => op.Order)
                .Select(op => op.Order.MapToPublic())
                .ToListAsync();
            }
        }

        public static async Task<IReadOnlyList<IProductImage>> GetImagesAsync(this IProduct _product)
        {
            if (_product == null) throw new ArgumentNullException(nameof(_product), "Cannot map NULL value");

            using (var context = new WebshopContext())
            {
                return await context.Set<ProductImage>()
                .Where(pi => pi.ProductID == _product.ProductID)
                .Select(pi => pi.MapToPublic())
                .ToListAsync();
            }
        }
        public static async Task<ICategory> GetCategoryAsync(this IProduct _product)
        {
            if (_product == null) throw new ArgumentNullException(nameof(_product), "Cannot map NULL value");

            using (var context = new WebshopContext())
            {
                return await context.Set<Category>()
                .Where(c => c.CategoryID == _product.CategoryID)
                .MapToPublic()
                .SingleOrDefaultAsync();
            }
        }
        public static async Task<IBrand> GetBrandAsync(this IProduct _product)
        {
            if (_product == null) throw new ArgumentNullException(nameof(_product), "Cannot map NULL value");

            using (var context = new WebshopContext())
            {
                return await context.Set<Brand>()
                .Where(c => c.BrandID == _product.BrandID)
                .MapToPublic()
                .SingleOrDefaultAsync();
            }
        }
    }
}
