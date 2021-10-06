using System.Collections.Generic;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    /// <summary>
    /// Defines a product type
    /// </summary>
    public class Type
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int TypeID { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Collection Navigational Property to the attached <see cref="Product"/>s
        /// </summary>
        public ICollection<Product> Products { get; set; }
    }
}
