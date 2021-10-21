using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class ProductTypeDTO
    {
        public int ProductID { get; set; }

        public ProductDTO Product { get; set; }

        public int TypeID { get; set; }

        public TypeDTO Type { get; set; }
    }
}
