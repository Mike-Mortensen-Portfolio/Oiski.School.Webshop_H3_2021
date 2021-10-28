using Microsoft.EntityFrameworkCore;
using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public static class UserExtensions
    {
        internal static IUser MapToPublic(this User _user)
        {
            if (_user == null) throw new ArgumentNullException(nameof(_user), "Cannot map NULL value");

            return new UserDTO
            {
                IsAdmin = _user.IsAdmin,
                CustomerID = _user.CustomerID,
                Password = _user.Password,
                UserID = _user.UserID
            };
        }
        internal static User MapToInternal(this IUser _user)
        {
            if (_user == null) throw new ArgumentNullException(nameof(_user), "Cannot map NULL value");

            return new User
            {
                IsAdmin = _user.IsAdmin,
                CustomerID = _user.CustomerID,
                Password = _user.Password,
                UserID = _user.UserID
            };
        }

        public static async Task<IReadOnlyList<IOrder>> GetOrderAsync(this IUser _user)
        {
            if (_user == null) throw new ArgumentNullException(nameof(_user), "Cannot map NULL value");

            using (var context = new WebshopContext())
            {
                return await context.Set<Order>()
                .Where(o => o.CustomerID == _user.CustomerID)
                .Select(o => o.MapToPublic())
                .ToListAsync();
            }
        }
        public static async Task<ICustomer> GetCustomerAsync(this IUser _user)
        {
            if (_user == null) throw new ArgumentNullException(nameof(_user), "Cannot map NULL value");

            return await new WebshopService().Customer.GetByIDAsync(_user.CustomerID);
        }
    }
}
