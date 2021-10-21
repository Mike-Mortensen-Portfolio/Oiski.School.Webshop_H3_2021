using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class ProductDTO
    {
        public int ProductID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string BrandName { get; set; }

        public decimal Price { get; set; }

        public int InStock { get; set; }

        public ICollection<ProductImageDTO> ProductImages { get; set; }

        public ICollection<ProductTypeDTO> Types { get; set; }
    }
}
