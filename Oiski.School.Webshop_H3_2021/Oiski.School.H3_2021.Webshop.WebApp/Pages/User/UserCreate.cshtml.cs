using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Oiski.School.Webshop_H3_2021.Servicelayer;
using Oiski.School.Webshop_H3_2021.Servicelayer.Extensions;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;

namespace Oiski.School.H3_2021.Webshop.WebApp.Pages.User
{
    public class UserCreateModel : PageModel
    {
        public UserCreateModel(WebshopContext _context)
        {
            context = _context;
        }

        private readonly WebshopContext context;

        #region PROPERTIES
        [BindProperty]
        public string FirstNameInput { get; set; }
        [BindProperty]
        public string LastNameInput { get; set; }
        [BindProperty]
        public string EmailInput { get; set; }
        [BindProperty]
        public string PasswordInput { get; set; }
        [BindProperty]
        public string ConfirmPasswordInput { get; set; }
        [BindProperty]
        public string AddressInput { get; set; }
        [BindProperty]
        public string PhoneInput { get; set; }
        [BindProperty]
        public string CountryInput { get; set; }
        [BindProperty]
        public string CityInput { get; set; }
        [BindProperty]
        public int ZipInput { get; set; }

        #endregion
        public void OnGet()
        {

        }

        public IActionResult OnPostAddCustomer()
        {
            if (ModelState.IsValid)
            {
                var service = new WebshopService(context);

                UserDTO userDTO = service.GetUserByEmail(EmailInput);
                Customer customer;

                #region Legacy
                if (userDTO == null)
                {
                    customer = new Customer()
                    {
                        FirstName = FirstNameInput,
                        LastName = LastNameInput,
                        Email = EmailInput,
                        Address = AddressInput,
                        PhoneNumber = PhoneInput,
                        Country = CountryInput,
                        City = CityInput,
                        ZipCode = ZipInput
                    };

                    var user = new Webshop_H3_2021.Datalayer.Entities.User()
                    {
                        Password = PasswordInput
                    };

                    customer.User = user;

                    service.Add(customer);

                    return RedirectToPage("/Index");
                }
                #endregion

                #region Legacy
                customer = new Customer()
                {
                    CustomerID = userDTO.CustomerID,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Email = userDTO.Email,
                    Address = userDTO.Address,
                    PhoneNumber = userDTO.PhoneNumber,
                    Country = userDTO.Country,
                    City = userDTO.City,
                    ZipCode = userDTO.ZipCode
                };

                customer.User = new Webshop_H3_2021.Datalayer.Entities.User()
                {
                    Password = PasswordInput,
                    CustomerID = customer.CustomerID
                };

                service.Update(customer);
                #endregion

                return RedirectToPage("/Index");
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
