using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Oiski.School.Webshop_H3_2021.Servicelayer;
using Oiski.School.Webshop_H3_2021.Servicelayer.Extensions;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.H3_2021.Webshop.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebshopContext _context;

        #region PROPERTIES
        [BindProperty]
        public List<ProductDisplayDTO> Products { get; set; }
        [BindProperty]
        public string ImageURL { get; set; }
        [BindProperty]
        public Order Order { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty]
        public bool DescendingCheckbox { get; set; }
        public SelectList BrandSelect { get; set; }
        [BindProperty]
        public int SelectedBrand { get; set; }
        public SelectList TypeSelect { get; set; }
        [BindProperty]
        public int SelectedType { get; set; }
        [BindProperty]
        public OrderBy OrderByEnum { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        [BindProperty]
        public FilterPagingOptions FilterPageOptions { get; set; }

        #endregion

        public IndexModel(WebshopContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var _service = new WebshopService(_context);

            BrandSelect = new SelectList(_service.GetAllProducts(), nameof(ProductDTO.ProductID), nameof(ProductDTO.BrandName), SelectedBrand);
            TypeSelect = new SelectList(_service.GetAllTypes(), nameof(ProductTypeDTO.TypeID), nameof(ProductTypeDTO.Type.Name), SelectedType);

            FilterPageOptions = new FilterPagingOptions()
            {
                CurrentPage = this.CurrentPage,
                PageSize = 5,
                SearchKey = this.SearchString,
                SearchOptions = new OrderOptions()
                {
                    Ascending = DescendingCheckbox
                }
            };

            Products = _service.FilterPaging(FilterPageOptions).ToList();          
        }

        public void OnPostPerformSearch()
        {
            var _service = new WebshopService(_context);

            FilterPageOptions = new FilterPagingOptions()
            {
                CurrentPage = this.CurrentPage,
                BrandKey = SelectedBrand.ToString(),
                TypeIDKey = SelectedType,
                Order = OrderByEnum,
                PageSize = 5,
                SearchKey = this.SearchString,
                SearchOptions = new OrderOptions()
                {
                    Ascending = DescendingCheckbox
                }
            };

            BrandSelect = new SelectList(_service.GetAllProducts(), nameof(ProductDTO.ProductID), nameof(ProductDTO.BrandName), SelectedBrand);
            TypeSelect = new SelectList(_service.GetAllTypes(), nameof(ProductTypeDTO.TypeID), nameof(ProductTypeDTO.Type.Name), SelectedType);

            Products = _service.FilterPaging(FilterPageOptions).ToList();
        }

        public IActionResult OnPostAddToCart(int productID)
        {
            var _service = new WebshopService(_context);

            if (ModelState.IsValid)
            {
                ProductDTO product = _service.GetProductByID(productID);

                Order order = new Order()
                {
                    OrderDate = DateTime.Now,
                    Customer = new Customer(),
                    Products = new List<OrderProduct>()
                    {
                        new OrderProduct()
                        {
                            ProductID = product.ProductID
                        }
                    }
                };

                return Page();
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
