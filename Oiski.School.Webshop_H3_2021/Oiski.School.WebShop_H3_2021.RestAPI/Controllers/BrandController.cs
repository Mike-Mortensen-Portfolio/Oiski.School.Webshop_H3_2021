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
    public class BrandController : ControllerBase
    {
        public BrandController(IWebshopService _service)
        {
            service = _service;
        }

        private readonly IWebshopService service;

        [HttpGet("Brands")]
        public async Task<IReadOnlyList<IBrand>> GetAllAsync()
        {
            return await service.Brand.GetAllAsync();
        }

        [HttpGet("Brands/{_id:int}")]
        public async Task<IBrand> GetByIDAsync(int _id)
        {
            return await service.Brand.GetByIDAsync(_id);
        }

        [HttpPost("Brands/Add")]
        public async Task<bool> AddAsync(BrandDTO _brand)
        {
            return await service.Brand.AddAsync(_brand);
        }

        [HttpPut("Brands/Update")]
        public async Task<bool> UpdateAsync(BrandDTO _brand)
        {
            return await service.Brand.UpdateAsync(_brand);
        }

        [HttpDelete("Brands/Remove/{_id:int}")]
        public async Task<bool> RemoveAsync(int _id)
        {
            IBrand brand = await service.Brand.GetByIDAsync(_id);

            if (brand == null) return false;

            return await service.Brand.RemoveAsync(brand);
        }
    }
}
