using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    /// <summary>
    /// Serves as the <see langword="base"/> for all product variation <see langword="objects"/>
    /// and is the pure form of data recieved and transmitted through the Web API: <strong>Controller/Products/GetBy/ID/{_productID}</strong> call.
    /// </summary>
    public class ProductBase
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
    }
}
