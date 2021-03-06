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
    public class CustomerController : ControllerBase
    {
        public CustomerController(IWebshopService _service)
        {
            service = _service;
        }

        private readonly IWebshopService service;

        [HttpGet]
        [Route("Customers")]
        public async Task<IReadOnlyList<ICustomer>> GetAllCustomersAsync()
        {
            return await service.Customer.GetAllAsync();
        }

        [HttpGet]
        [Route("Customer/{_customerID:int}")]
        public async Task<ICustomer> GetCustomerByIDAsync(int _customerID)
        {
            return await service.Customer.GetByIDAsync(_customerID);
        }

        [HttpGet]
        [Route("Customer/{_customerEmail}")]
        public async Task<ICustomer> GetCustomerByEmailAsync(string _customerEmail)
        {
            return await service.Customer.GetByEmailAsync(_customerEmail);
        }

        [HttpGet]
        [Route("Customer/GetLogin/{_customerID:int}")]
        public async Task<IUser> GetLoginFromCustomerAsync(int _customerID)
        {
            ICustomer customer = await service.Customer.GetByIDAsync(_customerID);

            return await customer.GetLoginAsync();
        }

        [HttpPost]
        [Route("Customer/Create")]
        public async Task<bool> AddCustomerAsync(CustomerDTO _customer)
        {
            return await service.Customer.AddAsync(_customer);
        }

        [HttpPut]
        [Route("Customer/Update")]
        public async Task<bool> UpdateCustomerAsync(CustomerDTO _customer)
        {
            return await service.Customer.UpdateAsync(_customer);
        }

        [HttpDelete]
        [Route("Customer/Remove/{_customerID_int}")]
        public async Task<bool> RemoveCustomerAsyn(int _customerID)
        {
            ICustomer customer = await service.Customer.GetByIDAsync(_customerID);
            return await service.Customer.RemoveAsync(customer);
        }
    }
}
