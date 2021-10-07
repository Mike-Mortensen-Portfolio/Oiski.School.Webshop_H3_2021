using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    [Table ("Types")]
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
        public ICollection<ProductType> Products { get; set; }
    }
}
