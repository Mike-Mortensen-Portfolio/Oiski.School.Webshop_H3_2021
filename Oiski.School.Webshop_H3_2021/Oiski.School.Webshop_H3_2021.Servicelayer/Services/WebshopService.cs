using Microsoft.EntityFrameworkCore;
using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Linq;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Services
{
    public class WebshopService
    {
        public WebshopService(WebshopContext _context)
        {
            context = _context;
        }

        private readonly WebshopContext context;

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
            context.Remove(_entity);

            context.SaveChanges();
        }

        /// <summary>
        /// Builds an <see cref="IQueryable{T}"/> object that targets the type of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>An extendable query expression that targets a sequence of type <typeparamref name="T"/></returns>
        public IQueryable<T> GetQueryable<T>() where T : class
        {
            return context.Set<T>();
        }
    }
}
