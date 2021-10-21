using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Services
{
    public interface IWebshopLoginService
    {
        public bool ValidateUser(string _email, string _password, out UserDTO _user);

        public bool LoggedIn();

        public UserDTO GetLoggedUseer();

        public bool UserIsAdmin();

        public void EraseSessionData();
    }
}
