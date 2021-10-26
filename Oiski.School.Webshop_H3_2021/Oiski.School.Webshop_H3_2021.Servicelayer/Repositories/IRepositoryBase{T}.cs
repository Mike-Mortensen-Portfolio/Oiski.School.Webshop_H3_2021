using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<IQueryable<T>> GetAllAsync();

        Task<IQueryable<T>> GetByAsync(Expression<Func<T, bool>> _condition);

        Task<bool> AddAsync(T _entity);

        Task<bool> UpdateAsync(T _entity);

        Task<bool> RemoveAsync(T _entity);
    }
}
