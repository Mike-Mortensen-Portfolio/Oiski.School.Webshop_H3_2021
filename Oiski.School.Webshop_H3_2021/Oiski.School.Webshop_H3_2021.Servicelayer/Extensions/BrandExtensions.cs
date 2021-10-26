using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Extensions
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

        public static async Task<IReadOnlyList<IProduct>> GetProductsAsync(this IBrand _brand)
        {
            throw new NotImplementedException();
        }
    }
}
