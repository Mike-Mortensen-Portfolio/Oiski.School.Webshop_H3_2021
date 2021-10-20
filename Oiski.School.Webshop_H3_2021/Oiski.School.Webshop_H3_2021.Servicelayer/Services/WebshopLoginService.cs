using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Services
{
    public class WebshopLoginService
    {
        /// <summary>
        /// Requests a user validation against the DB and <see langword="outs"/> the user if the request was successful
        /// </summary>
        /// <param name="_email"></param>
        /// <param name="_password"></param>
        /// <param name="_user"></param>
        /// <returns><see langword="True"/> if the given <paramref name="_email"/> and <paramref name="_password"/> validates against DB. Otherwise, if not, <see langword="false"/></returns>
        public bool ValidateUser(string _email, string _password, out UserDTO _user)
        {
            using (var context = new WebshopContext())
            {
                var service = new WebshopService(context);

                var user = service.GetUserByEmail(_email);

                if (user != null && user.Password == _password)
                {
                    _user = user;

                    return true;
                }

                _user = null;

                return false;
            }
        }
    }
}
