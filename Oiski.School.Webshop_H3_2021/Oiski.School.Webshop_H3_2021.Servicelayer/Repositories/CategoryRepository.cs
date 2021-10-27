using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    internal class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(WebshopContext _context) : base(_context)
        {
        }

        public async Task<bool> Add(ICategory _category)
        {
            return await base.AddAsync(_category.MapToInternal());
        }

        public async Task<IReadOnlyList<ICategory>> GetAll()
        {
            return await Task.Run(() =>
            {
                return base.GetAllAsync().Result.MapToPublic().ToList();
            });
        }

        public async Task<ICategory> GetByID(int _id)
        {
            return await Task.Run(() =>
            {
                return base.GetByAsync(c => c.CategoryID == _id).Result.SingleOrDefault().MapToPublic();
            });
        }

        public async Task<bool> Remove(ICategory _category)
        {
            return await base.RemoveAsync(_category.MapToInternal());
        }

        public async Task<bool> Update(ICategory _category)
        {
            return await base.UpdateAsync(_category.MapToInternal());
        }
    }
}
