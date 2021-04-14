using Nancy.Authentication.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApi
{
    public class UserValidator : IUserValidator
    {
        public ClaimsPrincipal Validate(string username, string password)
        {
            if (username == "demo" && password == "demo")
            {
                return new ClaimsPrincipal(new GenericIdentity(username));
            }

            // Not recognised => anonymous.
            return null;
        }
    }
}
