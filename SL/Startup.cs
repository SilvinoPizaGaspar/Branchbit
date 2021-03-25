using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

//[assembly: OwinStartup(typeof(SL.Startup))]
[assembly: OwinStartupAttribute("SLConfig", typeof(SL.Startup))]

namespace SL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
