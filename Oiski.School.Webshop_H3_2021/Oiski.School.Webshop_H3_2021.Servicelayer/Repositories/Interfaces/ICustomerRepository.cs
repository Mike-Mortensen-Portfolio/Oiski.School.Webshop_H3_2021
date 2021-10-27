using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    public interface ICustomerRepository : ICrudRepository<ICustomer>
    {
        Task<IReadOnlyList<ICustomer>> GetAllAsync();
        Task<ICustomer> GetByEmailAsync(string _email);

        Task<ICustomer> GetByIDAsync(int _id);
    }
}
