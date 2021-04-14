using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtBearer
{
    public class LoginModule : NancyModule
    {
        public LoginModule()
        {
            Post("/login", _ =>
            {
                Rs rs = new Rs();
                User user = new User();
                var p = this.BindTo<User>(user);
                if (p.UserName == "a" && p.PassWord == "a")
                {
                    rs.Info = Token.GetJwt(p.UserName);
                }
                else
                {
                    rs.Info = "Err";
                }
                return Response.AsJson(rs);
            });
        }
    }

    internal class User
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }

    internal class Rs
    {
        public object Info { get; set; }
    }
}
