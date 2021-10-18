using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    [Table ("Customers")]
    public class Customer
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// Foreign Key to attached <see cref="CustomerLogin"/>
        /// </summary>
        public int? CustomerLoginID { get; set; }

        /// <summary>
        /// Reference Navigational Property to the attached <see cref="Entities.User"/>
        /// </summary>
        [ForeignKey(nameof(CustomerLoginID))]
        public User CustomerLogin { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public int ZipCode { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int PaymentMethod { get; set; }

        public int DeliveryType { get; set; }

        /// <summary>
        /// Collection Navigational Property to the attached collection of <see cref="Order"/>s previously made by the <see cref="Entities.Customer"/>
        /// </summary>
        public ICollection<Order> Orders { get; set; }
    }
}