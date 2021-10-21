using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class OrderProductDTO
    {
        public int ProductID { get; set; }
        public ProductDTO Product { get; set; }

        public int OrderID { get; set; }
        public OrderDTO Order { get; set; }

        /// <summary>
        /// The amount of the product
        /// </summary>
        public int Quantity { get; set; }
    }
}
