using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public static class BrandExtensions
    {
        internal static IBrand MapToPublic(this Brand _brand)
        {
            return new BrandDTO
            {
                BrandID = _brand.BrandID,
                Name = _brand.Name
            };
        }
        internal static Brand MapToInternal(this IBrand _brand)
        {
            return new Brand
            {
                BrandID = _brand.BrandID,
                Name = _brand.Name
            };
        }

        internal static IQueryable<IBrand> MapToPublic(this IQueryable<Brand> _brands)
        {
            return _brands.Select(b => new BrandDTO
            {
                BrandID = b.BrandID,
                Name = b.Name
            });
        }
        internal static IQueryable<Brand> MapToInternal(this IQueryable<IBrand> _brands)
        {
            return _brands.Select(b => new Brand
            {
                BrandID = b.BrandID,
                Name = b.Name
            });
        }

        public static async Task<IReadOnlyList<IProduct>> GetProductsAsync(this IBrand _brand)
        {
            throw new NotImplementedException();
        }
    }
}
