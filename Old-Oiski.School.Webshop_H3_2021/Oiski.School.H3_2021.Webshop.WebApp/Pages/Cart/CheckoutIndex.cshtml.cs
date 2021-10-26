using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Oiski.School.H3_2021.Webshop.WebApp.Pages.Cart
{
    public class CheckoutIndexModel : PageModel
    {
        #region PROPERTIES
        [BindProperty]
        public string FirstNameInput { get; set; }
        [BindProperty]
        public string LastNameInput { get; set; }
        [BindProperty]
        public string EmailInput { get; set; }
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
        [BindProperty]
        public bool VISACheckbox { get; set; }
        [BindProperty]
        public bool PostNordCheckbox { get; set; }
        [BindProperty]
        public bool GLSCheckbox { get; set; }
        [BindProperty]
        public bool PaypalCheckbox { get; set; }
        #endregion
        public void OnGet()
        {
        }

        public void OnPostConfirmCheckout()
        {
        }
    }
}
