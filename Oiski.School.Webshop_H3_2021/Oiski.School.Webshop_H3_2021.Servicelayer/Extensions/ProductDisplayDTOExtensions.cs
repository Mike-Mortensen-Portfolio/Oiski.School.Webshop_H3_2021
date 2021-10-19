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
        /// Filters a collection of <see cref="ProductDisplayDTO"/> <see langword="objects"/> based on <paramref name="_filterKey"/>. If <paramref name="_filterKey"/> is <see langword="null"/> or empty no filter is applied
        /// </summary>
        /// <param name="_products"></param>
        /// <param name="_filterKey"></param>
        /// <returns>A collection of <see cref="ProductDisplayDTO"/> <see langword="objects"/> filtered by <strong>Brand</strong></returns>
        public static IQueryable<ProductDisplayDTO> FilterByBrand(this IQueryable<ProductDisplayDTO> _products, string _filterKey)
        {
            if (string.IsNullOrWhiteSpace(_filterKey))
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

        /// <summary>
        /// Orders a collection of <see cref="ProductDisplayDTO"/> based on <paramref name="_orderBy"/> in either ascending or descending order depending on the <paramref name="_options"/> provided
        /// </summary>
        /// <param name="_products"></param>
        /// <param name="_orderBy"></param>
        /// <param name="_options"></param>
        /// <returns></returns>
        public static IQueryable<ProductDisplayDTO> Order(this IQueryable<ProductDisplayDTO> _products, OrderBy _orderBy, OrderOptions _options = null)
        {
            _options ??= new OrderOptions();

            return _orderBy switch
            {
                OrderBy.Title => ((_options.Ascending) ? (_products.OrderBy(p => p.Title)) : (_products.OrderByDescending(p => p.Title))),
                OrderBy.Brand => ((_options.Ascending) ? (_products.OrderBy(p => p.BrandName)) : (_products.OrderByDescending(p => p.BrandName))),
                OrderBy.Price => ((_options.Ascending) ? (_products.OrderBy(p => p.Price)) : (_products.OrderByDescending(p => p.Price))),
                OrderBy.InStock => ((_options.Ascending) ? (_products.OrderBy(p => p.InStock)) : (_products.OrderByDescending(p => p.InStock))),
                _ => throw new ArgumentOutOfRangeException(nameof(_orderBy), _orderBy, "Filter not found!"),
            };
        }

        /// <summary>
        /// Search in free text for a <see cref="ProductDisplayDTO.Title"/> that contains the <paramref name="_searchKey"/>
        /// </summary>
        /// <param name="_products"></param>
        /// <param name="_searchKey"></param>
        /// <returns>A collection of all the <see cref="ProductDisplayDTO"/> <see langword="objects"/> that matches the condition</returns>
        public static IQueryable<ProductDisplayDTO> FreeSearchTitle(this IQueryable<ProductDisplayDTO> _products, string _searchKey)
        {
            if (string.IsNullOrWhiteSpace(_searchKey))
            {
                return _products;
            }

            return _products.Where(p => p.Title.ToLower().Contains(_searchKey));
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
