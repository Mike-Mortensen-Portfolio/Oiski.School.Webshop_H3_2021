using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    internal class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(WebshopContext _context) : base(_context)
        {
        }

        public async Task<bool> AddAsync(IProduct _product)
        {
            return await base.AddAsync(_product.MapToInternal());
        }

        public async Task<IReadOnlyList<IProduct>> GetAll()
        {
            return await Task.Run(() =>
           {
               return base.GetAllAsync().Result.MapToPublic().ToList();
           });
        }

        public async Task<IReadOnlyList<IProduct>> GetByBrandAsync(int _brandID)
        {
            return await Task.Run(() =>
            {
                return base.GetByAsync(p => p.BrandID == _brandID).Result.MapToPublic().ToList();
            });
        }

        public async Task<IProduct> GetByIDAsync(int _id)
        {
            return await Task.Run(() =>
            {
                return base.GetByAsync(p => p.ProductID == _id).Result.SingleOrDefault().MapToPublic();
            });
        }

        public async Task<IReadOnlyList<IProduct>> GetByCategoryAsync(int _categoryID)
        {
            return await Task.Run(() =>
            {
                return base.GetByAsync(p => p.CategoryID == _categoryID).Result.MapToPublic().ToList();
            });
        }

        public async Task<bool> RemoveAsync(IProduct _product)
        {
            return await base.RemoveAsync(_product.MapToInternal());
        }

        public async Task<bool> UpdateAsync(IProduct _product)
        {
            return await base.UpdateAsync(_product.MapToInternal());
        }
    }
}
