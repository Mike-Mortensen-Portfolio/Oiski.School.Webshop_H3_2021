using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public static class UserExtensions
    {
        internal static IUser MapToPublic(this User _user)
        {
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
            throw new NotImplementedException();
        }
        public static async Task<ICustomer> GetCustomerAsync(this IUser _user)
        {
            throw new NotImplementedException();
        }
    }
}
