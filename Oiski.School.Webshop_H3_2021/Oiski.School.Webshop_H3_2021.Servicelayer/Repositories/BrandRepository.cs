using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    internal class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(WebshopContext _context) : base(_context)
        {
        }

        public async Task<bool> Add(IBrand _brand)
        {
            return await base.AddAsync(_brand.MapToInternal());
        }

        public async Task<IReadOnlyList<IBrand>> GetAll()
        {
            return await Task.Run(() =>
            {
                return base.GetAllAsync().Result.MapToPublic().ToList();
            });
        }

        public async Task<IBrand> GetByID(int _id)
        {
            return await Task.Run(() =>
            {
                return base.GetByAsync(b => b.BrandID == _id).Result.SingleOrDefault().MapToPublic();
            });
        }

        public async Task<bool> Remove(IBrand _brand)
        {
            return await base.RemoveAsync(_brand.MapToInternal());
        }

        public async Task<bool> Update(IBrand _brand)
        {
            return await base.UpdateAsync(_brand.MapToInternal());
        }
    }
}
