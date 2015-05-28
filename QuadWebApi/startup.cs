using Microsoft.Owin;
using Owin;
using QuadWebApi.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(QuadWebApi.Startup))]

namespace QuadWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //WebApi
            app.UseWebApi(WebApiConfig.Configure());

            //SignalR
            app.MapSignalR(SignalRConfig.Configure());
        }
    }
}