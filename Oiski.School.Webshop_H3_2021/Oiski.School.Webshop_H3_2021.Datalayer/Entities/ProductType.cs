using System.ComponentModel.DataAnnotations.Schema;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    [Table ("ProductTypes")]
    public class ProductType
    {
        /// <summary>
        /// Combined Primary key
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// Reference Navigational Property to the associated <see cref="Entities.Product"/>
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Combined Primary Key
        /// </summary>
        public int TypeID { get; set; }
        /// <summary>
        /// Reference Navigational Property to the associated <see cref="Entities.Type"/>
        /// </summary>
        public Type Type { get; set; }
    }
}
