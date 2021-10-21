using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer
{
    public class UserDTO : CustomerDTO
    {
        public int? UserID { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}
