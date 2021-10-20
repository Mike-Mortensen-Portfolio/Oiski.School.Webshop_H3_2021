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

namespace Oiski.School.H3_2021.Webshop.WebApp.Pages.ProductCRUD
{
    public class DeleteModel : PageModel
    {
        public DeleteModel(WebshopContext context)
        {
            _context = context;
        }

        private readonly WebshopContext _context;

        #region PROPERTIES
        [BindProperty]
        public Product Product { get; set; }
        #endregion
        public void OnGet(int productID)
        {
            var _service = new WebshopService(_context);

            Product = _service.GetQueryable<Product>()
                .Where(p => p.ProductID == productID)
                .Include(p => p.Types)
                    .ThenInclude(t => t.Type)
                .FirstOrDefault();
        }
    }
}
