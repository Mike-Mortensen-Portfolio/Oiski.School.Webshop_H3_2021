using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;

namespace Oiski.School.H3_2021.Webshop.WebApp.Pages.Cart
{
    public class ShoppingCartIndexModel : PageModel
    {
        public readonly WebshopContext _context;

        public ShoppingCartIndexModel(WebshopContext context)
        {
            _context = context;
        }

        #region PROPERTIES
        [BindProperty]
        public List<Product> Products { get; set; }
        [BindProperty]
        public Order Order { get; set; }
        [BindProperty]
        public string Message { get; set; }
        #endregion

        public void OnGet(int? orderID)
        {            
            var _service = new WebshopService(_context);
            
            Products = _service.GetQueryable<Product>()
                    .Include(p => p.Types)
                        .ThenInclude(pt => pt.Type)
                    .Include(p => p.Orders)
                    .ToList();

            if (orderID != null)
            {
                Order = (Order)_service.GetQueryable<Order>()
                    .Where(o => o.OrderID == orderID);

                Products = _service.GetQueryable<Product>()
                    .Include(p => p.Types)
                        .ThenInclude(pt => pt.Type)
                    .Include(p => p.Orders)
                    .ToList();
            }
            else
            {
                Message = "You have no items in your cart. Return to home page to browse.";
            }

        }
    }
}
