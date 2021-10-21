using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class OrderDTO
    {
        public int OrderID { get; set; }

        public int CustomerID { get; set; }

        public CustomerDTO Customer { get; set; }

        public DateTime OrderDate { get; set; }

        public ICollection<OrderProductDTO> Products { get; set; }
    }
}
