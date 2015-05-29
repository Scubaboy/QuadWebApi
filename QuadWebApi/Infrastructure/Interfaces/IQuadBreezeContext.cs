using QuadWebApi.Infrastructure.BreezeContextProviders.Quad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadWebApi.Infrastructure.Interfaces
{
    public interface IQuadBreezeContext<T> where T : class, new()
    {
         QuadBreezeContextProvider<T> ContextProvider{get;}
    }
}
