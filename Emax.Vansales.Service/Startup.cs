using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Emax.Vansales.Service.Startup))]

namespace Emax.Vansales.Service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //comment//comment2
            ConfigureAuth(app);
        }
    }
}
