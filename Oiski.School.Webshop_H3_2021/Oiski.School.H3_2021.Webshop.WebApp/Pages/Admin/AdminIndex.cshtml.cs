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

namespace Oiski.School.H3_2021.Webshop.WebApp.Pages.Admin
{
    public class AdminIndexModel : PageModel
    {
        public AdminIndexModel(WebshopContext context)
        {
            _context = context;
        }

        private readonly WebshopContext _context;

        #region PROPERTIES
        [BindProperty]
        public List<Product> Products { get; set; }
        #endregion

        public void OnGet()
        {
            var _service = new WebshopService(_context);
            Products = _service.GetQueryable<Product>()
                .Include(p => p.Types)
                .ThenInclude(pt => pt.Type)
                .ToList();
        }
    }
}
