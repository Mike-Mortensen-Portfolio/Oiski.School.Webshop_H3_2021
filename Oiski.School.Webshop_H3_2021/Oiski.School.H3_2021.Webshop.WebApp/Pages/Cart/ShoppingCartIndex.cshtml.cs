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

namespace Oiski.School.H3_2021.Webshop.WebApp.Pages.Cart
{
    public class ShoppingCartIndexModel : PageModel
    {
        public ShoppingCartIndexModel(WebshopContext context)
        {
            _context = context;
        }

        private readonly WebshopContext _context;

        #region PROPERTIES
        [BindProperty]
        public List<ProductDTO> Products { get; set; }
        [BindProperty]
        public List<OrderProductDTO> OrderProducts { get; set; }
        [BindProperty]
        public OrderDTO Order { get; set; }
        [BindProperty]
        public string Message { get; set; }
        #endregion

        public void OnGet(int? orderID)
        {            
            var _service = new WebshopService(_context);

            //OrderProducts = _service.GetOrderProductsByOrder(orderID.Value) as List<OrderProductDTO>;
        }
    }
}
