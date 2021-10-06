using System.Collections.Generic;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
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

        /// <summary>
        /// Collection Navigational Property to the collection of <see cref="ProductImage"/>s attached to the <see cref="Product"/>
        /// </summary>
        public ICollection<ProductImage> ProductImages { get; set; }

        public int InStock { get; set; }

        /// <summary>
        /// Collection Navigational Property to the attached collection of <see cref="Entities.Type"/>s
        /// </summary>
        public ICollection<Type> Types { get; set; }
    }
}
