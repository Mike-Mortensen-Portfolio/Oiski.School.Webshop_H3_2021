using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    public interface ICategoryRepository : ICrudRepository<ICategory>
    {
        new Task<IReadOnlyList<ICategory>> GetAllAsync();
    }
}
