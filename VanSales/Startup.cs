using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(VanSales.Startup))]

namespace VanSales
{
    public partial class Startup
    {//this.date.getDate is not a function
        public void Configuration(IAppBuilder app)
        {
            //comment
            ConfigureAuth(app);
        }
    }
}
