using System;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class OrderDTO : IOrder
    {
        public int OrderID { get; }
        public int CustomerID { get; }
        public DateTime OrderDate { get; }
        public IOrder.PaymentMethod Payment { get; }
        public IOrder.DeliveryType Delivery { get; }
    }
}
