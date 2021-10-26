﻿using System;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public interface IOrder
    {
        int OrderID { get; }
        int CustomerID { get; }
        DateTime OrderDate { get; }

        PaymentMethod Payment { get; }
        DeliveryType Delivery { get; }

        public enum PaymentMethod
        {
            Paypal,
            VISA,
            Mastercard
        }

        public enum DeliveryType
        {
            PostNord,
            DAO,
            GLS
        }
    }
}
