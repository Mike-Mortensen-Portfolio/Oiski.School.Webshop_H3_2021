using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    public interface IBrandRepository
    {
        Task<bool> Add(IBrand _brand);
        Task<bool> Update(IBrand _brand);
        Task<bool> Remove(IBrand _brand);

        Task<IReadOnlyList<IBrand>> GetAll();
        Task<IBrand> GetByID(int _id);
    }
}
