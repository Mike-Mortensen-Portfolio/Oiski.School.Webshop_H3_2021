using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    /// <summary>
    /// Contains the login information of a <see cref="Entities.Customer"/>
    /// </summary>
    [Table("Users")]
    public class User
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Foreign Key to the attached <see cref="Entities.Customer"/>
        /// </summary>
        public int CustomerID { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        /// <summary>
        /// Reference Navigational Property to <see cref="Entities.Customer"/>
        /// </summary>
        public Customer Customer { get; set; }
    }
}
