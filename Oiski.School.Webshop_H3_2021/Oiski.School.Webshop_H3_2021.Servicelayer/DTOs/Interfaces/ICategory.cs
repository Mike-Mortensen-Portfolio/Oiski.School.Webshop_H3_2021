using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public interface ICategory
    {
        public int CategoryID { get; }

        public string Name { get; }
    }
}
