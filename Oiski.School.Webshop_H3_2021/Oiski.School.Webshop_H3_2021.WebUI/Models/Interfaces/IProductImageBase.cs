using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    public interface IProductImageBase
    {
        int ProductImageID { get; }
        int ProductID { get; }
        string Title { get; }
        string ImageURL { get; }
    }
}
