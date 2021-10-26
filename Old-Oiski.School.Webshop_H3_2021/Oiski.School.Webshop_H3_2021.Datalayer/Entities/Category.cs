using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    [Table("Categories")]
    public class Category
    {
        /// <summary>
        /// PRimary key
        /// </summary>
        public int CategoryID { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Collection Navigational Property to the collection of <see cref="Product"/>/>
        /// </summary>
        public ICollection<Product> Products { get; set; }
    }
}
