using System.ComponentModel.DataAnnotations.Schema;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    [Table("ProductImages")]
    public class ProductImage
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int ProductImageID { get; set; }

        /// <summary>
        /// Foreign Key to the attached <see cref="Entities.Product"/>
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// The <see cref="byte"/> data of the image (<i>The actual image</i>)
        /// </summary>
        public string ImageURL { get; set; }

        public string Title { get; set; }
    }
}
