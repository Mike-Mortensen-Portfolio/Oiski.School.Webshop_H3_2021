using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    public class ProductCreate : ProductBase, IProductCreate
    {
        public IReadOnlyList<IProductImageBase> ProductImages { get; set; }
    }
}
