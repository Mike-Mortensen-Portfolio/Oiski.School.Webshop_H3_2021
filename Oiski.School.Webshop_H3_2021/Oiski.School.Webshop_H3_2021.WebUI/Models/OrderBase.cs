using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    /// <summary>
    /// Serves as the <see langword="base"/> for all Order variation <see langword="objects"/>
    /// and is the pure form of data recieved and transmitted through the Web API: <strong>Controller/Orders/GetBy/ID/{_OrderID}</strong> call.
    /// </summary>
    public class OrderBase
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public PaymentType TypeOfPayment { get; set; }
        public DeliveryType TypeOfDelivery { get; set; }
    }

    public enum PaymentType
    {
        Paypal,
        VISA,
        Mastercard
    }

    public enum DeliveryType
    {
        [Display(Name = "Post Nord")]
        PostNord,
        DAO,
        GLS
    }
}
