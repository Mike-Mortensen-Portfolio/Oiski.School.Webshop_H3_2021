using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    public interface ICrudRepository<T>
    {
        Task<bool> AddAsync(T _entity);
        Task<bool> UpdateAsync(T _entity);
        Task<bool> RemoveAsync(T _entity);
    }
}
