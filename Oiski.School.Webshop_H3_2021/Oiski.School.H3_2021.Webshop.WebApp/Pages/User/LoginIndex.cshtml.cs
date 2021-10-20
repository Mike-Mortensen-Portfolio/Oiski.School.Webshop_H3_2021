using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        }
    }
}
