using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    /// <summary>
    /// Serves as the <see langword="base"/> for all category variation <see langword="objects"/>
    /// and is the pure form of data recieved and transmitted through the Web API: <strong>Controller/Categories/GetBy/ID/{_categoryID}</strong> call.
    /// </summary>
    public class CategoryBase
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}
