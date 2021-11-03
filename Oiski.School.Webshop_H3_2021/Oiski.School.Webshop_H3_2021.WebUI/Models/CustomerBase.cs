using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oiski.School.Webshop_H3_2021.WebUI
{
    /// <summary>
    /// Serves as the <see langword="base"/> for all customer variation <see langword="objects"/>
    /// and is the pure form of data recieved and transmitted through the Web API: <strong>Controller/Customers/GetBy/ID/{_customerID}</strong> call.
    /// </summary>
    public class CustomerBase
    {
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
