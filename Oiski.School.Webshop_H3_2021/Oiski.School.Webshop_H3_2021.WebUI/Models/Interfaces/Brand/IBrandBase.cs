using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    public interface IBrandBase
    {
        int BrandID { get; set; }
        string Name { get; set; }
    }
}
