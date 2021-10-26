using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    [Table("Customers")]
    public class Customer
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// Foreign Key to <see cref="User"/>
        /// </summary>
        public int? UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        /// <summary>
        /// Reference Navigational Property to the attached <see cref="Entities.User"/>
        /// </summary>
        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
    }
}
