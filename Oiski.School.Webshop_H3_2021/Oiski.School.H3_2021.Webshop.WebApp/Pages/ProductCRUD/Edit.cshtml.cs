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
        private readonly IWebshopService service;

        public EditModel(IWebshopService _service)
        {
            service = _service;
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
        public decimal ProductPriceInput { get; set; }
        [BindProperty]
        public int ProductInStockInput { get; set; }
        [BindProperty]
        public ProductDTO Product { get; set; }
        #endregion

        public void OnGet(int productID)
        {
            Product = service.GetProductByID(productID);
        }

        public IActionResult OnPostUpdateProduct()
        {
            if (ModelState.IsValid)
            {
                if (Product != null)
                {
                    Product product = new Product()
                    {
                        ProductID = Product.ProductID,
                        Title = ProductTitleInput,
                        Description = ProductDescriptionInput,
                        BrandName = ProductBrandNameInput,
                        Price = ProductPriceInput,
                        InStock = ProductInStockInput
                    };

                    service.Update(product);

                    return RedirectToPage("/Index");
                }
                else
                {
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
