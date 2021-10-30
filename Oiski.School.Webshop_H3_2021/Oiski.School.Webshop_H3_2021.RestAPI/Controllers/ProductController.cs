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
    public class ProductController : ControllerBase
    {
        public ProductController(IWebshopService _service)
        {
            service = _service;
        }

        private readonly IWebshopService service;

        [HttpGet]
        [Route("Products")]
        public async Task<IReadOnlyList<IProduct>> GetAllProductsAsync()
        {
            return await service.Product.GetAllAsync();
        }

        [HttpGet]
        [Route("Products/{_productID:int}")]
        public async Task<IProduct> GetProductByIDAsync(int _productID)
        {
            return await service.Product.GetByIDAsync(_productID);
        }

        [HttpGet]
        [Route("Products/ByBrand/{_brandID:int}")]
        public async Task<IReadOnlyList<IProduct>> GetProductByBrandAsync(int _brandID)
        {
            return await service.Product.GetByBrandAsync(_brandID);
        }

        [HttpGet]
        [Route("Products/ByCategory/{_categoryID:int}")]
        public async Task<IReadOnlyList<IProduct>> GetProductByCategoryAsync(int _categoryID)
        {
            return await service.Product.GetByCategoryAsync(_categoryID);
        }

        [HttpGet]
        [Route("Products/GetBrand/{_productID:int}")]
        public async Task<IBrand> GetBrandAsync(int _productID)
        {
            IProduct product = await service.Product.GetByIDAsync(_productID);

            IBrand brand = await product.GetBrandAsync();
            return brand;
        }

        [HttpGet]
        [Route("Products/GetCategory/{_productID:int}")]
        public async Task<ICategory> GetCategoryAsync(int _productID)
        {
            IProduct product = await service.Product.GetByIDAsync(_productID);

            ICategory category = await product.GetCategoryAsync();
            return category;
        }

        [HttpGet]
        [Route("Products/GetImages/{_productID:int}")]
        public async Task<IReadOnlyList<IProductImage>> GetImagesAsync(int _productID)
        {
            IProduct product = await service.Product.GetByIDAsync(_productID);

            return await product.GetImagesAsync();
        }

        [HttpGet]
        [Route("Products/GetOrders/{_productID:int}")]
        public async Task<IReadOnlyList<IOrder>> GetOrdersAsync(int _productID)
        {
            IProduct product = await service.Product.GetByIDAsync(_productID);

            return await product.GetOrdersAsync();
        }

        [HttpPost]
        [Route("Products/Create")]
        public async Task<bool> AddProductAsync(ProductDTO _product)
        {
            return await service.Product.AddAsync(_product);
        }

        //[HttpPost]
        //[Route("Products/CreateWithImage")]
        //public async Task<bool> AddProductWithImageAsync(ProductDTO _product, List<ProductImageDTO> _productImages)
        //{
        //    return await service.Product.AddAsync(_product, _productImages);
        //}

        [HttpPut]
        [Route("Products/Update")]
        public async Task<bool> UpdateProductAsync(ProductDTO _product)
        {
            return await service.Product.UpdateAsync(_product);
        }

        [HttpDelete]
        [Route("Products/Remove/{_productID:int}")]
        public async Task<bool> RemoveProductAsync(int _productID)
        {
            IProduct product = await service.Product.GetByIDAsync(_productID);
            return await service.Product.RemoveAsync(product);
        }
    }
}
