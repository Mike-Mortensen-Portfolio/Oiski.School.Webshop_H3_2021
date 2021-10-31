using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    public interface IRepositoryBase<T> : ICrudRepository<T>
    {
        Task<IQueryable<T>> GetByAsync(Expression<Func<T, bool>> _condition);
    }
}
