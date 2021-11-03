using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    public interface IOrderBase
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public PaymentType TypeOfPayment { get; set; }
        public DeliveryType TypeOfDelivery { get; set; }
    }
}
