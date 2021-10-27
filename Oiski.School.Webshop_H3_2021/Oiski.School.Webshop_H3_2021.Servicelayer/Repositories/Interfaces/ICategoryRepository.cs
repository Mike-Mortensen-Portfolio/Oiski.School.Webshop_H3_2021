using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    public interface ICategoryRepository
    {
        Task<bool> AddAsync(ICategory _brand);
        Task<bool> UpdateAsync(ICategory _brand);
        Task<bool> RemoveAsync(ICategory _brand);

        Task<IReadOnlyList<ICategory>> GetAllAsync();
        Task<ICategory> GetByIDAsync(int _id);
    }
}
