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
        public LoginIndexModel(WebshopLoginService _loginService)
        {
            LoginService = _loginService;
        }

        #region PROPERTIES
        public WebshopLoginService LoginService { get; }
        [BindProperty]
        public string EmailInput { get; set; }
        [BindProperty]
        public string PasswordInput { get; set; }
        #endregion

        public IActionResult OnGet()
        {
            //  If the user is logged in we want to sign them out
            if (LoginService.LoggedIn())
            {
                LoginService.EraseSessionData();

                return RedirectToPage("/Index");
            }

            return Page();
        }

        public IActionResult OnPostLogin()
        {
            if (LoginService.ValidateUser(EmailInput, PasswordInput, out UserDTO _user))
            {
                if (_user.IsAdmin)
                {
                    return RedirectToPage("/User/AdminIndex");
                }

                return RedirectToPage("/Index");
            }

            return Page();

            //  Add Error message here for [Email does not exist or password is wrong]
        }
    }
}
