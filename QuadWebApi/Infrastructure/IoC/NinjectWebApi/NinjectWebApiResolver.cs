using Ninject;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;

namespace QuadWebApi.Infrastructure.IoC.NinjectWebApi
{
    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot resolver;

		internal NinjectDependencyScope(IResolutionRoot resolver)
		{
			Contract.Assert(resolver != null);

			this.resolver = resolver;
		}

		public void Dispose()
		{
			resolver = null;
		}

		public object GetService(Type serviceType)
		{
			if (resolver == null)
				throw new ObjectDisposedException("this", "This scope has already been disposed");

			return resolver.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			if (resolver == null)
				throw new ObjectDisposedException("this", "This scope has already been disposed");

			return resolver.GetAll(serviceType);
		}
	}

	public class NinjectWebApiResolver : NinjectDependencyScope, IDependencyResolver
	{
		private IKernel kernel;

		public NinjectWebApiResolver(IKernel kernel)
			: base(kernel)
		{
			this.kernel = kernel;
		}

		public IDependencyScope BeginScope()
		{
			return new NinjectDependencyScope(kernel);
		}
	}
}