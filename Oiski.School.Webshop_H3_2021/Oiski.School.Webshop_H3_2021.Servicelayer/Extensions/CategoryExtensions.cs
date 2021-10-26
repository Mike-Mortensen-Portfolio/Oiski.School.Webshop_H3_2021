using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Extensions
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

        public static async Task<IReadOnlyList<IProduct>> GetProductsAsync(this ICategory _category)
        {
            throw new NotImplementedException();
        }
    }
}
