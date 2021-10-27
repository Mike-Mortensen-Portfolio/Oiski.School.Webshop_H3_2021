using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Repositories
{
    public interface IOrderRepository : ICrudRepository<IOrder>
    {
        Task<IReadOnlyList<IOrder>> GetAllAsync();
        Task<IOrder> GetByIDAsync(int _id);
        Task<IReadOnlyList<IOrder>> GetByCustomerAsync(int _userID);
        Task<IReadOnlyList<IOrder>> GetByDeliveryTypeAsync(IOrder.DeliveryType _deliveryType);
        Task<IReadOnlyList<IOrder>> GetByPaymentMethodAsync(IOrder.PaymentMethod _paymentMethod);
    }
}
