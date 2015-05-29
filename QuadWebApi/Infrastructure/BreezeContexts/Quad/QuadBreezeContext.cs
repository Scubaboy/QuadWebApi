using QuadWebApi.Infrastructure.BreezeContextProviders.Quad;
using QuadWebApi.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuadWebApi.Infrastructure.BreezeContexts.Quad
{
    internal class QuadBreezeContext<T> : IQuadBreezeContext<T> where T : class, new()
    {
        private QuadBreezeContextProvider<T> contextProvider;

        public QuadBreezeContext()
        {
            contextProvider = new QuadBreezeContextProvider<T>();
        }

        public QuadBreezeContextProvider<T> ContextProvider
        {
            get { return this.contextProvider; }
        }
    }
}