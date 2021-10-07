using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    [Table("Products")]
    public class Product
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int ProductID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string BrandName { get; set; }

        public decimal Price { get; set; }

        public int InStock { get; set; }

        /// <summary>
        /// Collection Navigational Property to the collection of <see cref="Order"/>s that the <see cref="Product"/> exists in
        /// </summary>
        public ICollection<OrderProduct> Orders { get; set; }

        /// <summary>
        /// Collection Navigational Property to the collection of <see cref="ProductImage"/>s attached to the <see cref="Product"/>
        /// </summary>
        public ICollection<ProductImage> ProductImages { get; set; }

        /// <summary>
        /// Collection Navigational Property to the attached collection of <see cref="Entities.Type"/>s
        /// </summary>
        public ICollection<ProductType> Types { get; set; }
    }
}
