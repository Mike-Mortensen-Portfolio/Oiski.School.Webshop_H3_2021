using Microsoft.EntityFrameworkCore;
using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    internal abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public RepositoryBase(WebshopContext _context)
        {
            context = _context;
        }

        protected readonly WebshopContext context;

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return context.Set<T>()
                .AsNoTracking();
            });
        }

        public async Task<IQueryable<T>> GetByAsync(Expression<Func<T, bool>> _condition)
        {
            return await Task.Run(() =>
            {
                return context.Set<T>()
                    .Where(_condition)
                    .AsNoTracking();
            });
        }

        /// <summary>
        /// Marks <paramref name="_entity"/> of type <typeparamref name="T"/> as <see cref="Microsoft.EntityFrameworkCore.EntityState.Added"/> and adds it to the tracker, then saves the changes (<i>Pushes to DB</i>)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_entity">The entity to push to DB</param> 
        public async Task<bool> AddAsync(T _entity)
        {
            return await Task.Run(() =>
            {
                context.Add(_entity);
                return (context.SaveChanges() > 0);
            });
        }

        /// <summary>
        /// Marks <paramref name="_entity"/> of type <typeparamref name="T"/> as <see cref="Microsoft.EntityFrameworkCore.EntityState.Modified"/> and adds it to the tracker, then saves the changes (<i>Pushes to DB</i>)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_entity">The entity to push to DB</param> 
        public async Task<bool> UpdateAsync(T _entity)
        {
            return await Task.Run(() =>
            {
                context.Update(_entity);
                return (context.SaveChanges() > 0);
            });
        }

        /// <summary>
        /// Marks <paramref name="_entity"/> of type <typeparamref name="T"/> as <see cref="Microsoft.EntityFrameworkCore.EntityState.Deleted"/> and then saves the changes (<i>Pushes to DB</i>)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_entity">The entity to push to DB</param> 
        public async Task<bool> RemoveAsync(T _entity)
        {
            return await Task.Run(() =>
            {
                context.Remove(_entity);
                return (context.SaveChanges() > 0);
            });
        }
    }
}
