using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    [Table("Orders")]
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
        /// Foreign Key to the attached <see cref="Entities.Customer"/>
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// Reference Navigational Property to <see cref="Entities.Customer"/>
        /// </summary>
        public Customer Customer { get; set; }

        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Collection Navigational Property to the purchased <see cref="Product"/>s
        /// </summary>
        public ICollection<OrderProduct> Products { get; set; }
    }
}
