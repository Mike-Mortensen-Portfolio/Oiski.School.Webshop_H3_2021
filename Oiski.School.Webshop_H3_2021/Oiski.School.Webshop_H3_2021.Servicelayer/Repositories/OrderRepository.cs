using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    internal class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(WebshopContext _context) : base(_context)
        {
        }

        public async Task<bool> AddAsync(IOrder _order)
        {
            return await base.AddAsync(_order.MapToInternal());
        }

        public async Task<IReadOnlyList<IOrder>> GetByCustomerAsync(int _customerID)
        {
            return await Task.Run(() =>
            {
                return base.GetByAsync(o => o.CustomerID == _customerID).Result.MapToPublic().ToList();
            });
        }

        public async Task<IReadOnlyList<IOrder>> GetByDeliveryTypeAsync(IOrder.DeliveryType _deliveryType)
        {
            return await Task.Run(() =>
            {
                return base.GetByAsync(o => o.TypeOfDelivery == (Order.DeliveryType)_deliveryType).Result.MapToPublic().ToList();
            });
        }

        public async Task<IOrder> GetByIDAsync(int _id)
        {
            return await Task.Run(() =>
            {
                return base.GetByAsync(o => o.OrderID == _id).Result.SingleOrDefault().MapToPublic();
            });
        }

        public async Task<IReadOnlyList<IOrder>> GetByPaymentMethodAsync(IOrder.PaymentMethod _paymentMethod)
        {
            return await Task.Run(() =>
            {
                return base.GetByAsync(o => o.TypeOfPayment == (Order.PaymentMethod)_paymentMethod).Result.MapToPublic().ToList();
            });
        }

        public async Task<bool> RemoveAsync(IOrder _order)
        {
            return await base.RemoveAsync(_order.MapToInternal());
        }

        public async Task<bool> UpdateAsync(IOrder _order)
        {
            return await base.UpdateAsync(_order.MapToInternal());
        }

        new public async Task<IReadOnlyList<IOrder>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return base.GetAllAsync().Result.MapToPublic().ToList();
            });
        }
    }
}
