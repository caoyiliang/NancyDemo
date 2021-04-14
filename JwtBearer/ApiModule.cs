using Nancy;
using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtBearer
{
    public class ApiModule : NancyModule
    {
        public ApiModule()
        {
            this.RequiresAuthentication();
            Get("/", _ => "hello");
        }
    }
}
