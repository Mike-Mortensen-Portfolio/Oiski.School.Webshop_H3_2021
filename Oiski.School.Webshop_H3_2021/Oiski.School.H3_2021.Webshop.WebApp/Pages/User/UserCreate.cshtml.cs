using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Oiski.School.H3_2021.Webshop.WebApp.Pages.User
{
    public class UserCreateModel : PageModel
    {
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
        public string ZipInput { get; set; }
        #endregion
        public void OnGet()
        {

        }

        public void OnPostAddCustomer()
        {

        }
    }
}
