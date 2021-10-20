using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class OrderProductDTO
    {
        /// <summary>
        /// Reference Navigational Property to the associated <see cref="Entities.Product"/>
        /// </summary>
        public ProductDTO Product { get; set; }

        /// <summary>
        /// Reference Navigational Property to the associated <see cref="Entities.Order"/>
        /// </summary>
        public OrderDTO Order { get; set; }

        /// <summary>
        /// The amount of the product
        /// </summary>
        public int Quantity { get; set; }
    }
}
