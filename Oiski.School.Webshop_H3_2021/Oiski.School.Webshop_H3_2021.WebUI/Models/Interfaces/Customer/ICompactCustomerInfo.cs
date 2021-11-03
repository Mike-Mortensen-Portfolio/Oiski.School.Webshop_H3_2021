using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    interface ICompactCustomerInfo
    {
        public int CustomerID { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}
