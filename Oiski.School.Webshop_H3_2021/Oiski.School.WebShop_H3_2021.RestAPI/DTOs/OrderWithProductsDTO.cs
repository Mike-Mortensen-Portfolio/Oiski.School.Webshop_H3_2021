using Oiski.School.Webshop_H3_2021.Servicelayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.WebShop_H3_2021.RestAPI
{
    public class OrderWithProductsDTO : OrderDTO
    {
        public ICollection<OrderProductDTO> Products { get; set; }
    }
}
