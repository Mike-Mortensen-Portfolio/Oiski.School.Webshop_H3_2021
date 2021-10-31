using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class BrandDTO : IBrand
    {
        public int BrandID { get; set; }
        public string Name { get; set; }
    }
}
