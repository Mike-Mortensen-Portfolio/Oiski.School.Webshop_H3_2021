using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class OrderProductDTO : IOrderProduct
    {
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
    }
}
