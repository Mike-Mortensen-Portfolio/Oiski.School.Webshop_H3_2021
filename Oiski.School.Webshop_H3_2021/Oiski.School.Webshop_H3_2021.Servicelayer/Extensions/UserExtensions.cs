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
        public static UserDTO MapSingleToBaseDTO(this User _user)
        {
            if (_user.Customer == null)
            {
                using (var context = new WebshopContext())
                {
                    WebshopService service = new WebshopService(context);

                    _user.Customer = service.GetQueryable<Customer>()
                        .SingleOrDefault(c => c.CustomerID == _user.CustomerID);
                }
            }

            return new UserDTO
            {
                UserID = _user.UserID,
                Address = _user.Customer.Address,
                IsAdmin = _user.IsAdmin,
                City = _user.Customer.City,
                Country = _user.Customer.Country,
                DeliveryType = _user.Customer.DeliveryType,
                Email = _user.Customer.Email,
                FirstName = _user.Customer.FirstName,
                LastName = _user.Customer.LastName,
                Orders = _user.Customer.Orders.ConvertToDTOList(),
                Password = _user.Password,
                PaymentMethod = _user.Customer.PaymentMethod,
                PhoneNumber = _user.Customer.PhoneNumber,
                ZipCode = _user.Customer.ZipCode
            };
        }

        public static IQueryable<UserDTO> MapToBaseDTO(this IQueryable<User> _users)
        {
            return _users
                .Select(u => new UserDTO
                {
                    UserID = u.UserID,
                    Address = u.Customer.Address,
                    IsAdmin = u.IsAdmin,
                    City = u.Customer.City,
                    Country = u.Customer.Country,
                    DeliveryType = u.Customer.DeliveryType,
                    Email = u.Customer.Email,
                    FirstName = u.Customer.FirstName,
                    LastName = u.Customer.LastName,
                    Orders = u.Customer.Orders.ConvertToDTOList(),
                    Password = u.Password,
                    PaymentMethod = u.Customer.PaymentMethod,
                    PhoneNumber = u.Customer.PhoneNumber,
                    ZipCode = u.Customer.ZipCode
                });
        }
    }
}
