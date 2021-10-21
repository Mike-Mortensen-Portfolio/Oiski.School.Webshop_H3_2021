using Microsoft.AspNetCore.Mvc;
using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.H3_2021.Webshop.WebApp.ViewComponents
{
    public class ProductsInStockViewComponent : ViewComponent
    {
        private readonly WebshopContext _context;

        public ProductsInStockViewComponent(WebshopContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(int productID)
        {
            var service = new WebshopService(_context);

            var products = service.GetProductByID(productID);

            return View(products);
        }
    }
}
