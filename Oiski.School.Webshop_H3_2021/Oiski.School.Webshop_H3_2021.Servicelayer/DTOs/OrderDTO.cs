using System;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class OrderDTO : IOrder
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public IOrder.PaymentMethod TypeOfPayment { get; set; }
        public IOrder.DeliveryType TypeOfDelivery { get; set; }
    }
}
