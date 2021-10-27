using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    internal class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(WebshopContext _context) : base(_context)
        {
        }

        public async Task<bool> AddAsync(ICustomer _customer)
        {
            return await base.AddAsync(_customer.MapToInternal());
        }

        public async Task<IReadOnlyList<ICustomer>> GetAll()
        {
            return await Task.Run(() =>
            {
                return base.GetAllAsync().Result.MapToPublic().ToList();
            });
        }

        public async Task<ICustomer> GetByEmail(string _email)
        {
            return await Task.Run(() =>
            {
                return base.GetByAsync(c => c.Email == _email).Result.SingleOrDefault().MapToPublic();
            });
        }

        public async Task<ICustomer> GetByID(int _id)
        {
            return await Task.Run(() =>
            {
                return base.GetByAsync(c => c.CustomerID == _id).Result.SingleOrDefault().MapToPublic();
            });
        }

        public async Task<bool> RemoveAsync(ICustomer _customer)
        {
            return await base.RemoveAsync(_customer.MapToInternal());
        }

        public async Task<bool> UpdateAsync(ICustomer _customer)
        {
            return await base.UpdateAsync(_customer.MapToInternal());
        }
    }
}
