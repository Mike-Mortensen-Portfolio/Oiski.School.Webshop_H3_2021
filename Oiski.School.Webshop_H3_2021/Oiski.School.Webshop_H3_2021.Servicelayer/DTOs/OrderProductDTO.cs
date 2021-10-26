using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class OrderProductDTO : IOrderProduct
    {
        public int ProductID { get; }
        public int OrderID { get; }
        public int Quantity { get; }
    }
}
