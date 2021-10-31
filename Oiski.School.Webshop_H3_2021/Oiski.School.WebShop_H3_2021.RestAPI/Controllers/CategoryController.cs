using Microsoft.AspNetCore.Mvc;
using Oiski.School.Webshop_H3_2021.Servicelayer;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.WebShop_H3_2021.RestAPI.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class CategoryController : ControllerBase
    {
        public CategoryController(IWebshopService _service)
        {
            service = _service;
        }

        private readonly IWebshopService service;

        [HttpGet("Categories")]
        public async Task<IReadOnlyList<ICategory>> GetAllAsync()
        {
            return await service.Category.GetAllAsync();
        }

        [HttpGet("Cateories/{_id:int}")]
        public async Task<ICategory> GetByIDAsync(int _id)
        {
            return await service.Category.GetByIDAsync(_id);
        }

        [HttpPost("Categories/Add")]
        public async Task<bool> AddAsync(CategoryDTO _category)
        {
            return await service.Category.AddAsync(_category);
        }

        [HttpPut("Categories/Update")]
        public async Task<bool> UpdateAsync(CategoryDTO _category)
        {
            return await service.Category.UpdateAsync(_category);
        }

        [HttpDelete("Categories/Remove/{_id}")]
        public async Task<bool> RemoveAsync(int _id)
        {
            ICategory category = await service.Category.GetByIDAsync(_id);

            if (category == null) return false;

            return await service.Category.RemoveAsync(category);
        }
    }
}
