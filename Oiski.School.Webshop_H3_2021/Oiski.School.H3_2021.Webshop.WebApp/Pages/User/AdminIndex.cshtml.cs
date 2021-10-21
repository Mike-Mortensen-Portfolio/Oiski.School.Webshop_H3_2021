using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Servicelayer;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;

namespace Oiski.School.H3_2021.Webshop.WebApp.Pages.User
{
    public class AdminIndexModel : PageModel
    {
        public AdminIndexModel(WebshopContext _context)
        {
            context = _context;
        }

        private readonly WebshopContext context;

        #region PROPERTIES
        [BindProperty]
        public List<ProductDTO> Products { get; set; }
        #endregion

        public void OnGet()
        {
            var service = new WebshopService(context);
            Products = service.GetAllProducts()
                .ToList();
        }
    }
}
