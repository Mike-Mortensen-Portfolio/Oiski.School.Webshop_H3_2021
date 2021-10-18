using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
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
        public List<Product> Products { get; set; }
        [BindProperty]
        public string SearchString { get; set; }
        public SelectList BrandSelect { get; set; }
        public SelectList TypeSelect { get; set; }
        #endregion

        public IndexModel(WebshopContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var _service = new WebshopService(_context);
            Products = _service.GetQueryable<Product>()
                .Include(p => p.Types)
                .ThenInclude(pt => pt.Type)
                .ToList();
        }

        public async Task<IActionResult> PerformSearch()
        {
            return Page();
        }
    }
}
