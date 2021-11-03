using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    public class ProductImageBase : IProductImageBase
    {
        public int ProductImageID { get; set; }
        public int ProductID { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
    }
}
