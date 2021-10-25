using Microsoft.AspNetCore.Mvc;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Oiski.School.Webshop_H3_2021.Servicelayer;
using Oiski.School.Webshop_H3_2021.Servicelayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.RestAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CustomerController : ControllerBase
    {
        public CustomerController(IWebshopService _service)
        {
            service = _service;
        }

        private readonly IWebshopService service;

        [HttpGet]
        [Route("Customers")]
        public ICollection<UserDTO> GetAllCustomers()
        {
            return service.GetAllCustomers()
                .ToList();
        }

        [HttpGet]
        [Route("Customer/{_id:int}")]
        public UserDTO GetUserByID(int _id)
        {
            return service.GetUserByID(_id);
        }

        [HttpGet]
        [Route("Customer/_email:string")]
        public UserDTO GetUserByEmail(string _email)
        {
            return service.GetUserByEmail(_email);
        }

        [HttpPost]
        [Route("Customer/Create")]
        public void AddCustomer(Customer _customer)
        {
            service.Add(_customer);
        }

        [HttpPut]
        [Route("Customer/Update")]
        public void UpdateCustomer(Customer _customer)
        {
            service.Update(_customer);
        }

        [HttpDelete]
        [Route("Customer/Delete")]
        public void DeleteCustomer(Customer _customer)
        {
            service.Remove(_customer);
        }
    }
}
