using System;
using System.Collections.Generic;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    /// <summary>
    /// Defines an order made by a <see cref="Customer"/>
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// Foreign Key to the attached <see cref="Customer"/>
        /// </summary>
        public int CustomerID { get; set; }

        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Collection Navigational Property to the purchased <see cref="Product"/>s
        /// </summary>
        public List<Product> Products { get; set; }
    }
}
