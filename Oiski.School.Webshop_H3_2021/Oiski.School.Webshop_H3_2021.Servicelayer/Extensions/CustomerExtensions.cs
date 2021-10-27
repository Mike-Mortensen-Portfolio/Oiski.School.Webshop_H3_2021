using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public static class CustomerExtensions
    {
        internal static ICustomer MapToPublic(this Customer _customer)
        {
            if (_customer == null) throw new ArgumentNullException(nameof(_customer), "Cannot map NULL value");

            return new CustomerDTO
            {
                Address = _customer.Address,
                PhoneNumber = _customer.PhoneNumber,
                Country = _customer.Country,
                CustomerID = _customer.CustomerID,
                Email = _customer.Email,
                FirstName = _customer.FirstName,
                LastName = _customer.LastName,
                UserID = _customer.UserID,
                ZipCode = _customer.ZipCode
            };
        }
        internal static Customer MapToInternal(this ICustomer _customer)
        {
            if (_customer == null) throw new ArgumentNullException(nameof(_customer), "Cannot map NULL value");

            return new Customer
            {
                Address = _customer.Address,
                PhoneNumber = _customer.PhoneNumber,
                Country = _customer.Country,
                CustomerID = _customer.CustomerID,
                Email = _customer.Email,
                FirstName = _customer.FirstName,
                LastName = _customer.LastName,
                UserID = _customer.UserID,
                ZipCode = _customer.ZipCode
            };
        }

        internal static IQueryable<ICustomer> MapToPublic(this IQueryable<Customer> _customers)
        {
            if (_customers == null) throw new ArgumentNullException(nameof(_customers), "Cannot map NULL value");

            return _customers.Select(c => new CustomerDTO
            {
                Address = c.Address,
                PhoneNumber = c.PhoneNumber,
                Country = c.Country,
                CustomerID = c.CustomerID,
                Email = c.Email,
                FirstName = c.FirstName,
                LastName = c.LastName,
                UserID = c.UserID,
                ZipCode = c.ZipCode
            });
        }

        internal static IQueryable<Customer> MapToInternal(this IQueryable<ICustomer> _customers)
        {
            if (_customers == null) throw new ArgumentNullException(nameof(_customers), "Cannot map NULL value");

            return _customers.Select(c => new Customer
            {
                Address = c.Address,
                PhoneNumber = c.PhoneNumber,
                Country = c.Country,
                CustomerID = c.CustomerID,
                Email = c.Email,
                FirstName = c.FirstName,
                LastName = c.LastName,
                UserID = c.UserID,
                ZipCode = c.ZipCode
            });
        }

        public static async Task<IUser> GetLoginAsync(this ICustomer _customer)
        {
            if (_customer == null) throw new ArgumentNullException(nameof(_customer), "Cannot map NULL value");

            return await Task.Run(() =>
            {
                using (var context = new WebshopContext())
                {
                    return context.Set<User>().SingleOrDefault(u => u.UserID == _customer.UserID).MapToPublic();
                }
            });
        }
    }
}
