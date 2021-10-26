//using Microsoft.AspNetCore.Mvc;
//using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
//using Oiski.School.Webshop_H3_2021.Servicelayer;
//using Oiski.School.Webshop_H3_2021.Servicelayer.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Oiski.School.Webshop_H3_2021.RestAPI.Controllers
//{
//    [ApiController]
//    [Route("[Controller]")]
//    public class ProductController : ControllerBase
//    {
//        public ProductController(IWebshopService _service)
//        {
//            service = _service;
//        }

//        private readonly IWebshopService service;

//        [HttpGet]
//        [Route("Products")]
//        public ICollection<ProductDTO> AllProducts()
//        {
//            try
//            {
//                return service.GetAllProducts().ToList();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception();
//            }
//        }

//        [HttpGet]
//        [Route("Products/{_id}")]
//        public ProductDTO OneProduct(int _productID)
//        {
//            try
//            {
//                return service.GetProductByID(_productID);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception();
//            }
//        }

//        [HttpPost]
//        [Route("Products/Create")]
//        public void CreateProduct(Product _product)
//        {
//            try
//            {                
//                service.Add(_product);
//            }
//            catch (Exception ex)
//            {

//                throw new Exception();
//            }
//        }

//        [HttpPut]
//        [Route("Products/Update")]
//        public void UpdateProduct(Product _product)
//        {
//            try
//            {
//                service.Update(_product);
//            }
//            catch (Exception ex)
//            {

//                throw new Exception();
//            }
//        }

//        [HttpDelete]
//        [Route("Products/Delete")]
//        public void DeleteProduct(Product _product)
//        {
//            try
//            {
//                service.Remove(_product);
//            }
//            catch (Exception ex)
//            {

//                throw new Exception();
//            }
//        }
//    }
//}
