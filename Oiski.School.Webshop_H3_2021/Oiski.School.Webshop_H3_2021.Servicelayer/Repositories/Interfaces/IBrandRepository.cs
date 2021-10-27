using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    public interface IBrandRepository
    {
        Task<bool> AddAsync(IBrand _brand);
        Task<bool> UpdateAsync(IBrand _brand);
        Task<bool> RemoveAsync(IBrand _brand);

        Task<IReadOnlyList<IBrand>> GetAllAsync();
        Task<IBrand> GetByIDAsync(int _id);
    }
}
