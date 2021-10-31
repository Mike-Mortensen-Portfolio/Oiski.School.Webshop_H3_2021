using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public static class CategoryExtensions
    {
        internal static ICategory MapToPublic(this Category _category)
        {
            if (_category == null) throw new ArgumentNullException(nameof(_category), "Cannot map NULL value");

            return new CategoryDTO
            {
                CategoryID = _category.CategoryID,
                Name = _category.Name
            };
        }
        internal static Category MapToInternal(this ICategory _category)
        {
            if (_category == null) throw new ArgumentNullException(nameof(_category), "Cannot map NULL value");

            return new Category
            {
                CategoryID = _category.CategoryID,
                Name = _category.Name
            };
        }

        internal static IQueryable<ICategory> MapToPublic(this IQueryable<Category> _categories)
        {
            if (_categories == null) throw new ArgumentNullException(nameof(_categories), "Cannot map NULL value");

            return _categories.Select(c => new CategoryDTO
            {
                CategoryID = c.CategoryID,
                Name = c.Name
            });
        }
        internal static IQueryable<Category> MapToInternal(this IQueryable<ICategory> _categories)
        {
            if (_categories == null) throw new ArgumentNullException(nameof(_categories), "Cannot map NULL value");

            return _categories.Select(c => new Category
            {
                CategoryID = c.CategoryID,
                Name = c.Name
            });
        }

        public static async Task<IReadOnlyList<IProduct>> GetProductsAsync(this ICategory _category)
        {
            if (_category == null) throw new ArgumentNullException(nameof(_category), "Cannot map NULL value");

            return await new WebshopService().Product.GetByCategoryAsync(_category.CategoryID);
        }
    }
}
