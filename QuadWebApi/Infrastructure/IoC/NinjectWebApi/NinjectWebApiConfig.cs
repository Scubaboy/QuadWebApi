using Ninject;
using Ninject.Web.Common;
using QuadEntityFramework.DbContexts;
using QuadWebApi.Infrastructure.BreezeContexts.Quad;
using QuadWebApi.Infrastructure.Interfaces;
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
            kernel.Bind<ISmtp>().To<TestI>().InRequestScope();
            kernel.Bind<IQuadBreezeContext<QuadDbContext>>().To<QuadBreezeContext<QuadDbContext>>().InRequestScope();
            return kernel;
        }
    }
}