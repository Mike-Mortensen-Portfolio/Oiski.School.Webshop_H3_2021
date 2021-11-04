using System;
using System.Collections.Generic;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    public interface IEditableOrder : IOrderDisplay
    {
        new public int CustomerID { get; set; }
        new public DateTime OrderDate { get; set; }
        new public PaymentType TypeOfPayment { get; set; }
        new public DeliveryType TypeOfDelivery { get; set; }

        new IList<CartProductBase> Products { get; set; }
    }
}
