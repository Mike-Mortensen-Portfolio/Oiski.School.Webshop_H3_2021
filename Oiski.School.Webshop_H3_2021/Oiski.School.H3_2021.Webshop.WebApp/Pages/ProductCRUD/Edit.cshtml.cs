using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Oiski.School.Webshop_H3_2021.Servicelayer;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;

namespace Oiski.School.H3_2021.Webshop.WebApp.Pages.ProductCRUD
{
    public class EditModel : PageModel
    {
        private readonly WebshopContext _context;

        public EditModel(WebshopContext context)
        {
            _context = context;
        }

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
        public ProductDisplayDTO ProductDTO { get; set; }
        #endregion

        public void OnGet(int productID)
        {
            var _service = new WebshopService(_context);

            ProductDTO = _service.GetQueryable<ProductDisplayDTO>()
                .Where(p => p.ProductID == productID)
                .FirstOrDefault();
        }        

        public void OnPostUpdateProduct()
        {

        }
    }
}
