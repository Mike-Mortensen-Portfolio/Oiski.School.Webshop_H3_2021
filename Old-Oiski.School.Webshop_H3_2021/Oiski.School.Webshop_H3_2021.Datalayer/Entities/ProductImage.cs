using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    [Table("ProductImages")]
    public class ProductImage
    {
        /// <summary>
        ///  Primary Key
        /// </summary>
        public int ProductImageID { get; set; }

        /// <summary>
        /// Foreign Key to <see cref="Product"/>
        /// </summary>
        public int ProductID { get; set; }

        public string ImageURL { get; set; }

        public string Title { get; set; }
    }
}
