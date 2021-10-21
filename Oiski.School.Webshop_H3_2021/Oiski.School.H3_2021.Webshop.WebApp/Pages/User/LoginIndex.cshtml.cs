using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oiski.School.Webshop_H3_2021.Servicelayer;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;

namespace Oiski.School.H3_2021.Webshop.WebApp.Pages.User
{
    public class LoginIndexModel : PageModel
    {
        #region PROPERTIES
        [BindProperty]
        public string EmailInput { get; set; }
        [BindProperty]
        public string PasswordInput { get; set; }
        #endregion

        public void OnGet()
        {

        }

        public void OnPostLogin()
        {
            var service = new WebshopLoginService();

            if (service.ValidateUser(EmailInput, PasswordInput, out UserDTO _user))
            {
                HttpContext.Session.SetInt32("UserID", _user.UserID.Value);
                HttpContext.Session.SetString("UserEmail", _user.Email);

                return;
            }
            
            //  Add Error message here for [Email does not exist or password is wrong]
        }
    }
}
