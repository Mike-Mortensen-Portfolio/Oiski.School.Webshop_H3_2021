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
        public static UserDTO MapSingleToBaseDTO(this Customer _customer)
        {
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
                UserID = _customer.CustomerID,
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

        public static IQueryable<UserDTO> MapToBaseDTO(this IQueryable<Customer> _customers)
        {
            return _customers
                .Select(c => new UserDTO
                {
                    UserID = c.CustomerID,
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
