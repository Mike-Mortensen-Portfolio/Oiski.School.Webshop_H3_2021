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
    public class OrderController : ControllerBase
    {
        public OrderController(IWebshopService _service)
        {
            service = _service;
        }

        private readonly IWebshopService service;

        [HttpGet("Orders")]
        public async Task<IReadOnlyList<IOrder>> GetAllAsync()
        {
            return await service.Order.GetAllAsync();
        }

        [HttpGet("Orders/{_id:int}")]
        public async Task<IOrder> GetByIDAsync(int _id)
        {
            return await service.Order.GetByIDAsync(_id);
        }

        [HttpGet("Orders/GetBy/Customer/{_customerID:int}")]
        public async Task<IReadOnlyList<IOrder>> GetByCustomerAsync(int _customerID)
        {
            return await service.Order.GetByCustomerAsync(_customerID);
        }

        [HttpGet("Orders/GetBy/DeliveryType/{_deliveryType:int}")]
        public async Task<IReadOnlyList<IOrder>> GetByDeliveryTypeAsync(IOrder.DeliveryType _deliveryType)
        {
            return await service.Order.GetByDeliveryTypeAsync(_deliveryType);
        }

        [HttpGet("Orders/GetBy/PaymentMethod/{_paymentMethod:int}")]
        public async Task<IReadOnlyList<IOrder>> GetByDeliveryTypeAsync(IOrder.PaymentMethod _paymentMethod)
        {
            return await service.Order.GetByPaymentMethodAsync(_paymentMethod);
        }

        [HttpGet("Orders/Get/Products/{_orderID:int}")]
        public async Task<IReadOnlyList<IOrderProduct>> GetProductsAsync(int _orderID)
        {
            IOrder order = await service.Order.GetByIDAsync(_orderID);

            if (order == null) return null;

            return await order.GetProductsAsync();
        }

        [HttpGet("Orders/Get/Customer/{_orderID:int}")]
        public async Task<ICustomer> GetCustomerAsync(int _orderID)
        {
            IOrder order = await service.Order.GetByIDAsync(_orderID);

            if (order == null) return null;

            return await order.GetCustomerAsync();
        }

        [HttpPost("Orders/Add")]
        public async Task<bool> AddAsync(OrderWithProductsDTO _order)
        {
            return await service.Order.AddAsync(_order, _order.Products.ToList());
        }

        [HttpPut("Orders/Update")]
        public async Task<bool> UpdateAsync(OrderDTO _order)
        {
            return await service.Order.UpdateAsync(_order);
        }

        [HttpDelete("Orders/{_id:int}")]
        public async Task<bool> RemoveAsync(int _id)
        {
            IOrder order = await service.Order.GetByIDAsync(_id);

            if (order == null) return false;

            return await service.Order.RemoveAsync(order);
        }
    }
}
