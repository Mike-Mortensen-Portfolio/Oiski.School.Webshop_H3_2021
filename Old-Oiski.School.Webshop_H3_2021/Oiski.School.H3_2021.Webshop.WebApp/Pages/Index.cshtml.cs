﻿//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
//using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
//using Oiski.School.Webshop_H3_2021.Servicelayer;
//using Oiski.School.Webshop_H3_2021.Servicelayer.Extensions;
//using Oiski.School.Webshop_H3_2021.Servicelayer.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Oiski.School.H3_2021.Webshop.WebApp.Pages
//{
//    public class IndexModel : PageModel
//    {
//        public IndexModel(IWebshopService _service, IWebshopLoginService _loginService)
//        {
//            service = _service;
//            LoginService = _loginService;
//        }

//        private readonly IWebshopService service;
//        public IWebshopLoginService LoginService { get; }

//        #region PROPERTIES
//        [BindProperty]
//        public List<ProductDisplayDTO> Products { get; set; }
//        [BindProperty]
//        public string ImageURL { get; set; }
//        [BindProperty]
//        public Order Order { get; set; }
//        [BindProperty(SupportsGet = true)]
//        public string SearchString { get; set; }
//        [BindProperty]
//        public bool DescendingCheckbox { get; set; }
//        public SelectList BrandSelect { get; set; }
//        [BindProperty(SupportsGet = true)]
//        public string SelectedBrand { get; set; }
//        public SelectList TypeSelect { get; set; }
//        [BindProperty]
//        public int SelectedType { get; set; }
//        [BindProperty]
//        public OrderBy OrderByEnum { get; set; }
//        [BindProperty(SupportsGet = true)]
//        public int PageSize { get; set; }
//        [BindProperty(SupportsGet = true)]
//        public int CurrentPage { get; set; } = 1;
//        [BindProperty]
//        public FilterPagingOptions FilterPageOptions { get; set; }

//        #endregion
//        public void OnGet()
//        {                      
//            FilterPageOptions = new FilterPagingOptions()
//            {
//                CurrentPage = this.CurrentPage,
//                PageSize = 5,
//                SearchKey = this.SearchString,
//                SearchOptions = new OrderOptions()
//                {
//                    Ascending = DescendingCheckbox
//                }
//            };

//            Products = service.FilterPaging(FilterPageOptions).ToList();
//        }

//        public void OnPostPerformSearch()
//        {
//            FilterPageOptions = new FilterPagingOptions()
//            {
//                CurrentPage = this.CurrentPage,
//                Order = OrderByEnum,
//                PageSize = 5,
//                SearchKey = this.SearchString,
//                SearchOptions = new OrderOptions()
//                {
//                    Ascending = DescendingCheckbox
//                }
//            };

//            Products = service.FilterPaging(FilterPageOptions).ToList();
//        }

//        public IActionResult OnPostAddToCart(int productID)
//        {
//            if (ModelState.IsValid)
//            {
//                ProductDTO product = service.GetProductByID(productID);

//                Order order = new Order()
//                {
//                    OrderDate = DateTime.Now,
//                    Customer = new Customer(),
//                    Products = new List<OrderProduct>()
//                    {
//                        new OrderProduct()
//                        {
//                            ProductID = product.ProductID
//                        }
//                    }
//                };

//                return Page();
//            }
//            else
//            {
//                return RedirectToPage("/Error");
//            }
//        }
//    }
//}