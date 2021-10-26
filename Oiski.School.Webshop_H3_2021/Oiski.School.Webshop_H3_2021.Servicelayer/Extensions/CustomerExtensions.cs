using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Extensions
{
    public static class CustomerExtensions
    {
        internal static ICustomer MapToPublic(this Customer _customer)
        {
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

        public static async Task<IUser> GetLoginAsync(this ICustomer _customer)
        {
            throw new NotImplementedException();
        }
    }
}
