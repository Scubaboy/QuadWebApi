using Microsoft.AspNet.SignalR.Hubs;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuadWebApi.Infrastructure.IoC.NinjectSignalR
{
    public static class NinjectSignalRConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            //Create the bindings
         
            return kernel;
        }
    }
}