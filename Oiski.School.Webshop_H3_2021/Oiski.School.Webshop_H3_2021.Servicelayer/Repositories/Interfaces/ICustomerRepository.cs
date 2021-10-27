using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    public interface ICustomerRepository : ICrudRepository<ICustomer>
    {
        new Task<IReadOnlyList<ICustomer>> GetAllAsync();
        Task<ICustomer> GetByEmailAsync(string _email);
    }
}
