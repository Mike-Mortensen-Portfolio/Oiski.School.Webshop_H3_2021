using Oiski.School.Webshop_H3_2021.Datalayer.Domain;
using Oiski.School.Webshop_H3_2021.Datalayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Services
{
    public class WebshopLoginService : IWebshopLoginService
    {
        public WebshopLoginService(IHttpContextAccessor _httpContext)
        {
            httpContext = _httpContext.HttpContext;
        }
        private readonly HttpContext httpContext;

        public const string SESSIONIDKEY = "UserID";
        public const string SESSIONEMAILKEY = "UserEmail";

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

                if (user != null && user.UserID != null && user.Password == _password)
                {
                    _user = user;

                    SetSessionsData(_user);

                    return true;
                }

                _user = null;

                return false;
            }
        }

        /// <summary>
        /// Validates that the session contains a <see cref="SESSIONIDKEY"/>
        /// </summary>
        /// <returns><see langword="True"/> if a user is logged in. otherwise, if not, <see langword="false"/></returns>
        public bool LoggedIn()
        {
            return httpContext.Session.Keys.Contains(SESSIONIDKEY);
        }

        /// <summary>
        /// Pulls the logged user from DB
        /// </summary>
        /// <returns>The logged <see cref="UserDTO"/> if the user is in fact logged in. Otherwise, if not, <see langword="null"/></returns>
        public UserDTO GetLoggedUseer()
        {
            if (LoggedIn())
            {
                using (var context = new WebshopContext())
                {
                    var service = new WebshopService(context);

                    string email = httpContext.Session.GetString(SESSIONEMAILKEY);

                    return service.GetUserByEmail(email);
                }
            }

            return null;
        }

        /// <summary>
        /// Pulls the logged user from DB and validates its privilige level
        /// </summary>
        /// <returns><see langword="True"/> if the user is an admin. Otherwise, if not, <see langword="false"/></returns>
        public bool UserIsAdmin()
        {
            var user = GetLoggedUseer();

            if (user == null) return false;

            return user.IsAdmin;
        }

        /// <summary>
        /// Clears the login information stored in session (<i><strong>Note:</strong> this effectivily signs out the user</i>)
        /// </summary>
        public void EraseSessionData()
        {
            httpContext.Session.Remove(SESSIONIDKEY);
            httpContext.Session.Remove(SESSIONEMAILKEY);
        }

        /// <summary>
        /// Stores the login information in session
        /// </summary>
        /// <param name="_user"></param>
        private void SetSessionsData(UserDTO _user)
        {
            httpContext.Session.SetInt32(SESSIONIDKEY, _user.UserID.Value);
            httpContext.Session.SetString(SESSIONEMAILKEY, _user.Email);
        }

    }
}
