using System.ComponentModel.DataAnnotations.Schema;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    [Table("CustomerLogins")]
    /// <summary>
    /// Contains the login information of a <see cref="Entities.Customer"/>
    /// </summary>
    public class CustomerLogin
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int CustomerLoginID { get; set; }

        /// <summary>
        /// Foreign Key to the attached <see cref="Entities.Customer"/>
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// Reference Navigational Property to <see cref="Entities.Customer"/>
        /// </summary>
        public Customer Customer { get; set; }

        public string Password { get; set; }
    }
}
