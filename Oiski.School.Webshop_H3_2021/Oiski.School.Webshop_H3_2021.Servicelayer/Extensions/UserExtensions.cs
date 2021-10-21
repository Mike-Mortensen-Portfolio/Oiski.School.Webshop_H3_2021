using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Extensions
{
    public static class UserExtensions
    {
        /// <summary>
        /// Maps all properties of <paramref name="_customer"/> to a <see cref="UserDTO"/>
        /// </summary>
        /// <param name="_customer"></param>
        /// <returns>The mapped <see cref="UserDTO"/> if <paramref name="_customer"/> is not <see langword="null"/>. Otherwise returns <see langword="null"/></returns>
        public static UserDTO MapSingleToBaseDTO(this Customer _customer)
        {
            if (_customer == null) return null;

            if (_customer.User == null)
            {
                using (var context = new WebshopContext())
                {
                    WebshopService service = new WebshopService(context);

                    _customer.User = service.GetQueryable<User>()
                        .SingleOrDefault(u => u.CustomerID == _customer.CustomerID);
                }
            }

            return new UserDTO
            {
                CustomerID = _customer.CustomerID,
                UserID = _customer.UserID,
                Address = _customer.Address,
                IsAdmin = _customer.User.IsAdmin,
                City = _customer.City,
                Country = _customer.Country,
                DeliveryType = _customer.DeliveryType,
                Email = _customer.Email,
                FirstName = _customer.FirstName,
                LastName = _customer.LastName,
                Orders = _customer.Orders.ConvertToDTOList(),
                Password = _customer.User.Password,
                PaymentMethod = _customer.PaymentMethod,
                PhoneNumber = _customer.PhoneNumber,
                ZipCode = _customer.ZipCode
            };
        }

        /// <summary>
        /// Maps a collection of <see cref="Customer"/> <see langword="objects"/> to an <see cref="IQueryable{T}"/> <see langword="object"/> of type <see cref="UserDTO"/>
        /// </summary>
        /// <param name="_customers"></param>
        /// <returns>The mapped <see cref="IQueryable{T}"/> of type <see cref="UserDTO"/> if <paramref name="_customers"/> is not <see langword="null"/>. Otherwise returns <see langword="null"/></returns>
        public static IQueryable<UserDTO> MapToBaseDTO(this IQueryable<Customer> _customers)
        {
            if (_customers == null) return null;

            return _customers
                .Select(c => new UserDTO
                {
                    CustomerID = c.CustomerID,
                    UserID = c.UserID,
                    Address = c.Address,
                    IsAdmin = c.User.IsAdmin,
                    City = c.City,
                    Country = c.Country,
                    DeliveryType = c.DeliveryType,
                    Email = c.Email,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Orders = c.Orders.ConvertToDTOList(),
                    Password = c.User.Password,
                    PaymentMethod = c.PaymentMethod,
                    PhoneNumber = c.PhoneNumber,
                    ZipCode = c.ZipCode
                });
        }
    }
}
