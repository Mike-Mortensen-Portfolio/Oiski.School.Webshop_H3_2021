using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
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
            return new CategoryDTO
            {
                CategoryID = _category.CategoryID,
                Name = _category.Name
            };
        }
        internal static Category MapToInternal(this ICategory _category)
        {
            return new Category
            {
                CategoryID = _category.CategoryID,
                Name = _category.Name
            };
        }

        internal static IQueryable<ICategory> MapToPublic(this IQueryable<Category> _categories)
        {
            return _categories.Select(c => new CategoryDTO
            {
                CategoryID = c.CategoryID,
                Name = c.Name
            });
        }
        internal static IQueryable<Category> MapToInternal(this IQueryable<ICategory> _categories)
        {
            return _categories.Select(c => new Category
            {
                CategoryID = c.CategoryID,
                Name = c.Name
            });
        }

        public static async Task<IReadOnlyList<IProduct>> GetProductsAsync(this ICategory _category)
        {
            throw new NotImplementedException();
        }
    }
}
