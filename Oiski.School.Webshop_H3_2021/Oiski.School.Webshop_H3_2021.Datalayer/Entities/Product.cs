using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    [Table("Products")]
    public class Product
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Foreign Key to <see cref="Category"/>
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// Foreign Key to <see cref="Brand"/>
        /// </summary>
        public int BrandID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int InStock { get; set; }

        public bool IsDeleted { get; set; }

        public Category Category { get; set; }

        public Brand Brand { get; set; }

        /// <summary>
        /// Collection Navigational Property to the collection of <see cref="Order"/>s that the <see cref="Product"/> exists in
        /// </summary>
        public ICollection<OrderProduct> Orders { get; set; }

        /// <summary>
        /// Collection Navigational Property to the collection of <see cref="ProductImage"/>s attached to the <see cref="Product"/>
        /// </summary>
        public ICollection<ProductImage> ProductImages { get; set; }
    }
}
