using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Extensions
{
    public static class ProductDisplayDTOExtensions
    {
        /// <summary>
        /// If <paramref name="_filterKey"/> is <see langword="null"/> or empty no filter is applied
        /// </summary>
        /// <param name="_products"></param>
        /// <param name="_filterKey"></param>
        /// <returns></returns>
        public static IQueryable<ProductDisplayDTO> FilterByBrand(this IQueryable<ProductDisplayDTO> _products, string _filterKey)
        {
            if (string.IsNullOrEmpty(_filterKey))
            {
                return _products;
            }

            return _products.Where(p => p.BrandName == _filterKey);
        }

        /// <summary>
        /// Filters a collection of <see cref="ProductDisplayDTO"/> <see langword="objects"/> based on <paramref name="_typeID"/>. If <paramref name="_typeID"/> is less than 0 no filter is applied
        /// </summary>
        /// <param name="_products"></param>
        /// <param name="_typeID"></param>
        /// <returns>A collection of <see cref="ProductDisplayDTO"/> <see langword="objects"/> filtered by <strong>ProductType</strong></returns>
        public static IQueryable<ProductDisplayDTO> FilterByType(this IQueryable<ProductDisplayDTO> _products, int _typeID)
        {
            if (_typeID < 0)
            {
                return _products;
            }

            var query = _products.SelectMany(p => p.Types)
                .Where(pt => pt.TypeID == _typeID);

            return query.Join(_products,
                pt => pt.ProductID,
                p => p.ProductID,
                (pt, p) => new ProductDisplayDTO
                {
                    BrandName = p.BrandName,
                    Description = p.Description,
                    InStock = p.InStock,
                    Price = p.Price,
                    ProductID = p.ProductID,
                    ProductImage = p.ProductImage,
                    Title = p.Title,
                    Types = p.Types
                });
        }

        public static IQueryable<ProductDisplayDTO> Order(this IQueryable<ProductDisplayDTO> _products, OrderBy _orderBy, OrderOptions _options = null)
        {
            _options ??= new OrderOptions();

            return _orderBy switch
            {
                OrderBy.Title => _products.OrderBy(p => p.Title),
                OrderBy.Brand => _products.OrderBy(p => p.BrandName),
                OrderBy.Price => _products.OrderBy(p => p.Price),
                OrderBy.InStock => _products.OrderBy(p => p.InStock),
                _ => throw new ArgumentOutOfRangeException(nameof(_orderBy), _orderBy, "Filter not found!"),
            };
        }

        public static IQueryable<ProductDisplayDTO> Paging(this IQueryable<ProductDisplayDTO> _products, int _pageZeroStart, int _pageSize)
        {
            if (_pageSize == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(_pageSize), "_ pageSize cannot be zero.");
            }

            if (_pageZeroStart != 0)
            {
                _products.Skip(_pageZeroStart * _pageSize);
            }

            return _products.Take(_pageSize);
        }

    }
}
