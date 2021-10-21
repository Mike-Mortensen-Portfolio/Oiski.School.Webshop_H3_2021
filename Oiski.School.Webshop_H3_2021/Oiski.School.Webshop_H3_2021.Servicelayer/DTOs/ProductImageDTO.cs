using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class ProductImageDTO
    {
        public int ProductImageID { get; set; }

        public int ProductID { get; set; }

        public string ImageURL { get; set; }

        public string Title { get; set; }
    }
}
