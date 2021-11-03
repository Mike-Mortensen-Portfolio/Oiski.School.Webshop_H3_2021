using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    /// <summary>
    /// Represents a <see cref="ProductBase"/> with all associated images attached
    /// </summary>
    public class ProductDisplay : ProductBase, IProductDisplay
    {
        public IReadOnlyList<string> ImageURLs { get; set; }
    }
}
