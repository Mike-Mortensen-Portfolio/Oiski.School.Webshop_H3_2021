using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Oiski.School.Webshop_H3_2021.Servicelayer;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;

namespace Oiski.School.H3_2021.Webshop.WebApp.Pages.ProductCRUD
{
    public class DetailsModel : PageModel
    {
        public DetailsModel(WebshopContext context)
        {
            _context = context;
        }

        private readonly WebshopContext _context;

        #region PROPERTIES
        [BindProperty]
        public string ProductTitleInput { get; set; }
        [BindProperty]
        public string ProductDescriptionInput { get; set; }
        [BindProperty]
        public string ProductBrandNameInput { get; set; }
        [BindProperty]
        public string ProductTypeInput { get; set; }
        [BindProperty]
        public string ProductPriceInput { get; set; }
        [BindProperty]
        public int ProductInStockInput { get; set; }
        [BindProperty]
        public Product Product { get; set; }
        #endregion
        public void OnGet(int productID)
        {
            var _service = new WebshopService(_context);

        }
    }
}
