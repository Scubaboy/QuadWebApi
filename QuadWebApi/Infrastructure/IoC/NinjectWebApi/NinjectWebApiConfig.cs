using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuadWebApi.Infrastructure.IoC.NinjectWebApi
{
    public static class NinjectWebApiConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            //Create the bindings
            
            return kernel;
        }
    }
}