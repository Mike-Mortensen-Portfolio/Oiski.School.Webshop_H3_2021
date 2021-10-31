using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    [Table("OrderProducts")]
    public class OrderProduct
    {
        /// <summary>
        /// Combined Primary Key
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Reference Navigational Property to the associated <see cref="Entities.Product"/>
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Combined Primary Key
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// Reference Navigational Property to the associated <see cref="Entities.Order"/>
        /// </summary>
        public Order Order { get; set; }

        public int Quantity { get; set; }
    }
}
