using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    public interface IEditableProduct 
    {
        int ProductID { get; set; }
        int CategoryID { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        int BrandID { get; set; }
        decimal Price { get; set; }
        int InStock { get; set; }
    }
}
