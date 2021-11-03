using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    public interface ICartProductBase
    {
        public int ProductID { get; }
        public int OrderID { get; }
        public int Quantity { get; set; }
    }
}
