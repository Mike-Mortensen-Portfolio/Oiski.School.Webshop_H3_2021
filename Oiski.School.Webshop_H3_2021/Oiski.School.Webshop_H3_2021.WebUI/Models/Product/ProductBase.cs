using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    /// <summary>
    /// Serves as the <see langword="base"/> for all product variation <see langword="objects"/>
    /// and is the pure form of data recieved and transmitted through the Web API: <strong>Controller/Products/GetBy/ID/{_productID}</strong> call.
    /// </summary>
    public class ProductBase : IProductBase, ICompactProductInfo
    {
        public int ProductID { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int BrandID { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int InStock { get; set; }
    }
}
