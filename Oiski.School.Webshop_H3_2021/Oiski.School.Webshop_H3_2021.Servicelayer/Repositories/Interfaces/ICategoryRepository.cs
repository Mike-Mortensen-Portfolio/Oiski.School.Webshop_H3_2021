using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    public interface ICategoryRepository
    {
        Task<bool> Add(ICategory _brand);
        Task<bool> Update(ICategory _brand);
        Task<bool> Remove(ICategory _brand);

        Task<IReadOnlyList<ICategory>> GetAll();
        Task<ICategory> GetByID(int _id);
    }
}
