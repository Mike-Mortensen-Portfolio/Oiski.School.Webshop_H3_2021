using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public ShoppingCartIndexModel(IWebshopService _service)
        {
            service = _service;
        }

        private readonly IWebshopService service;

        #region PROPERTIES
        [BindProperty]
        public List<OrderProduct> OrderProducts { get; set; }
        [BindProperty]
        public OrderDTO Order { get; set; }
        [BindProperty]
        public string Message { get; set; }
        #endregion

        public void OnGet()
        {
            OrderProducts = new List<OrderProduct>();
        }
    }
}
