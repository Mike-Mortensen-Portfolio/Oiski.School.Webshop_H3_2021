using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using System;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Services
{
    public class WebshopService
    {
        private WebshopService() { context = new WebshopContext(); }   //  Private to ensure no instantiation outside of scope

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

        public void Add<T>(T _entity)
        {
            context.Add(_entity);
        }
    }
}
