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

        public static IQueryable<Product> Filter(this IQueryable<Product> _products, FilterBy _filterBy, string _filterKey, SearchOptions _options = null)
        {

            _options ??= new SearchOptions();

            switch (_filterBy)
            {
                case FilterBy.Brand:
                    return FilterByBrand(_products, _filterKey, _options.Ascending);
                case FilterBy.Type:
                    return FilterByType(_products, _filterKey, _options.Ascending);
                default:
                    throw new ArgumentOutOfRangeException(nameof(_filterKey), _filterKey, "No filter found for the specified value");
            }
        }

        #region Helper Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_products"></param>
        /// <param name="_filterKey"></param>
        /// <param name="_ascending"></param>
        /// <returns>An <see cref="IQueryable{T}"/> <see langword="object"/> that has been filtered by <see cref="Product.BrandName"/> based on a<paramref name="_filterKey"/></returns>
        private static IQueryable<Product> FilterByBrand(IQueryable<Product> _products, string _filterKey, bool _ascending = false)
        {
            var brandQuery = _products.Where(p => p.BrandName.Contains(_filterKey));

            if (_ascending)
            {
                return brandQuery.OrderBy(p => p.BrandName);
            }

            return brandQuery.OrderByDescending(p => p.BrandName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_products"></param>
        /// <param name="_filterKey"></param>
        /// <param name="_ascending"></param>
        /// <returns>An <see cref="IQueryable{T}"/> <see langword="object"/> that has been filtered by <see cref="ProductType.Type"/> based on a <paramref name="_filterKey"/></returns>
        private static IQueryable<Product> FilterByType(IQueryable<Product> _products, string _filterKey, bool _ascending = false)
        {
            var products = GetProductsWithTypesIncluded(_products);

            var productTypes = GetProductType(_products, _filterKey);

            var finalTypeQuery = products.Join(productTypes,
               p => p.ProductID,
               pt => pt.ProductID,
               (p, pt) => new { Product = p, orderBy = pt.Type.Name });

            if (_ascending)
            {
                return finalTypeQuery
                .OrderBy(projection => projection.orderBy)
                .Select(projection => projection.Product);
            }

            return finalTypeQuery
                .OrderByDescending(projection => projection.orderBy)
                .Select(projection => projection.Product);
        }

        /// <summary>
        /// Builds a query that collects all products and includes the associated type data
        /// </summary>
        /// <param name="_products"></param>
        /// <returns></returns>
        private static IQueryable<Product> GetProductsWithTypesIncluded(this IQueryable<Product> _products)
        {
            return _products.Include(p => p.Types)
                         .ThenInclude(pt => pt.Type);
        }

        /// <summary>
        /// Gets a flat collection of <see cref="ProductType"/> <see langword="objects"/>, in build from <paramref name="_products"/> that matches the <paramref name="_filterKey"/> 
        /// </summary>
        /// <param name="_products"></param>
        /// <param name="_filterKey"></param>
        /// <returns></returns>
        private static List<ProductType> GetProductType(this IQueryable<Product> _products, string _filterKey)
        {
            return _products.SelectMany(p => p.Types)
                            .Where(pt => pt.Type.Name.Contains(_filterKey))
                            .ToList();
        }
        #endregion
    }
}
