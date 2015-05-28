using Microsoft.AspNet.SignalR;
using QuadWebApi.Infrastructure.IoC.NinjectSignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuadWebApi.App_Start
{
    public static class SignalRConfig
    {
        public static HubConfiguration Configure()
        {
            var config = new HubConfiguration();

            config.Resolver = new NinjectSignalRResolver(NinjectSignalRConfig.CreateKernel());
            return config;
        }
    }
}