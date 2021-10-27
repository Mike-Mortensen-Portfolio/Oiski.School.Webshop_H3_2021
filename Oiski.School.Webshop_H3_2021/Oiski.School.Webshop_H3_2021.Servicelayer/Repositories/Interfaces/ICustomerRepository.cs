using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    public interface ICustomerRepository
    {
        Task<bool> AddAsync(ICustomer _customer);
        Task<bool> UpdateAsync(ICustomer _customer);
        Task<bool> RemoveAsync(ICustomer _customer);

        Task<IReadOnlyList<ICustomer>> GetAllAsync();
        Task<ICustomer> GetByIDAsync(int _id);
        Task<ICustomer> GetByEmailAsync(string _email);
    }
}
