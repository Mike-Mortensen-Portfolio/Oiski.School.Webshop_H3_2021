using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class CustomerDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public int ZipCode { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int PaymentMethod { get; set; }

        public int DeliveryType { get; set; }

        public ICollection<OrderDTO> Orders { get; set; }
    }
}
