using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    public interface IProductDisplay
    {
        int ProductID { get; }
        int CategoryID { get; }
        string Title { get; }
        string Description { get; }
        int BrandId { get; }
        decimal Price { get; }
        int InStock { get; }

        IReadOnlyList<string> ImageURLs { get; }
    }
}
