using System.Collections.Generic;


namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
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

        /// <summary>
        /// Collection Navigational Property to the attached collection of <see cref="Order"/>s previously made by the <see cref="Entities.Customer"/>
        /// </summary>
        public List<Order> Orders { get; set; }
    }
}
