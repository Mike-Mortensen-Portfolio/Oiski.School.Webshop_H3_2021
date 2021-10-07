using Microsoft.EntityFrameworkCore;
using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using System;
using System.Linq;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Services
{
    public class WebshopService
    {
        private WebshopService() //  Private to ensure no instantiation outside of scope
        {
            var option = new DbContextOptions<WebshopContext>();
            context = new WebshopContext(option);
        }

        private WebshopContext context;

        /// <summary>
        /// Simple Singleton pattern
        /// </summary>
        private static WebshopService access = null;
        public static WebshopService Access
        {
            get
            {
                if (access == null)
                {
                    access = new WebshopService();
                }

                return access;
            }
        }

        public void SetContext(WebshopContext _context)
        {
            context = _context;
        }

        public void FlushContext()
        {
            context = null;
        }

        /// <summary>
        /// Adds <paramref name="_entity"/> of type <typeparamref name="T"/> to the tracker and saves the changes (<i>Pushes to DB</i>)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_entity">The entity to push to DB</param>
        public void Add<T>(T _entity)
        {
            context.Add(_entity);

            context.SaveChanges();
        }

        /// <summary>
        /// Marks <paramref name="_entity"/> of type <typeparamref name="T"/> as <see cref="Microsoft.EntityFrameworkCore.EntityState.Modified"/> and adds it to the tracker, then saves the changes (<i>Pushes to DB</i>)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_entity">The entity to push to DB</param>
        public void Update<T>(T _entity)
        {
            context.Update(_entity);

            context.SaveChanges();
        }

        /// <summary>
        /// Adds <paramref name="_entity"/> of type <typeparamref name="T"/> to the tracker as <see cref="Microsoft.EntityFrameworkCore.EntityState.Deleted"/> and saves the changes (<i>Pushes to DB</i>)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_entity">The entity to push to DB</param>
        public void Remove<T>(T _entity)
        {
            EntityState state = context.Entry(_entity).State;
            context.Remove(_entity);

            context.SaveChanges();
        }

        /// <summary>
        /// Builds an <see cref="IQueryable{T}"/> object as an extendable query, based on the <paramref name="_condition"/> provided
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_condition"></param>
        /// <returns>An extendable query expression that targets a sequence of type <typeparamref name="T"/></returns>
        public IQueryable<T> Find<T>(Func<T, bool> _condition) where T : class
        {
            var query = context.Set<T>()
                .Where(_condition)
                .AsQueryable();

            return query;
        }
    }
}
