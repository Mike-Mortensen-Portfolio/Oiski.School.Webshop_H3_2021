using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    public class ProductDisplay
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public string ImageURL { get; set; }
    }
}
