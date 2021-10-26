using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    [Table("Orders")]
    public class Order
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// Foreign Key to Customer
        /// </summary>
        public int CustomerID { get; set; }

        public DateTime OrderDate { get; set; }

        public PaymentMethod TypeOfPayment { get; set; }
        public DeliveryType TypeOfDelivery { get; set; }

        public Customer Customer { get; set; }

        /// <summary>
        /// Collection Navigational Property to the purchased <see cref="Product"/>s
        /// </summary>
        public ICollection<OrderProduct> Products { get; set; }

        /// <summary>
        /// Enum for the user to choose a payment method.
        /// </summary>
        public enum PaymentMethod
        {
            Paypal,
            VISA,
            Mastercard
        }

        /// <summary>
        /// Enum for the user to choose a delivery type.
        /// </summary>
        public enum DeliveryType
        {
            PostNord,
            DAO,
            GLS
        }
    }
}
