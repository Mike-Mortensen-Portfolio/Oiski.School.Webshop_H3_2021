//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
//using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
//using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
//using Oiski.School.Webshop_H3_2021.Servicelayer;
//using Oiski.School.Webshop_H3_2021.Servicelayer.Services;

//namespace Oiski.School.H3_2021.Webshop.WebApp.Pages.ProductCRUD
//{
//    public class DeleteModel : PageModel
//    {
//        public DeleteModel(IWebshopService _service)
//        {
//            service = _service;
//        }

//        private readonly IWebshopService service;

//        #region PROPERTIES
//        [BindProperty]
//        public ProductDTO ProductDTO { get; set; }
//        #endregion
//        public void OnGet(int productID)
//        {
//            ProductDTO = service.GetProductByID(productID);
//        }

//        public IActionResult OnPostDeleteProduct()
//        {
//            if (ModelState.IsValid)
//            {
//                if (ProductDTO != null)
//                {
//                    Product product = new Product()
//                    {
//                        ProductID = ProductDTO.ProductID
//                    };

//                    service.Remove(product);

//                    return RedirectToPage("/Index");
//                }
//                else
//                {
//                    return Page();
//                }
//            }
//            else
//            {
//                return RedirectToPage("/Error");
//            }
//        }
//    }
//}
