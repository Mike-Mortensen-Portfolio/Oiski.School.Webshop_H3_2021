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
//    public class DetailsModel : PageModel
//    {
//        public DetailsModel(IWebshopService _service)
//        {
//            service = _service;
//        }

//        private readonly IWebshopService service;

//        #region PROPERTIES
//        [BindProperty]
//        public string ProductTitleInput { get; set; }
//        [BindProperty]
//        public string ProductDescriptionInput { get; set; }
//        [BindProperty]
//        public string ProductBrandNameInput { get; set; }
//        [BindProperty]
//        public string ProductTypeInput { get; set; }
//        [BindProperty]
//        public string ProductPriceInput { get; set; }
//        [BindProperty]
//        public int ProductInStockInput { get; set; }
//        [BindProperty]
//        public ProductDTO Product { get; set; }
//        [BindProperty]
//        public string ImageURL { get; set; }
//        #endregion
//        public void OnGet(int productID)
//        {
//            Product = service.GetProductByID(productID);
//        }
//    }
//}
