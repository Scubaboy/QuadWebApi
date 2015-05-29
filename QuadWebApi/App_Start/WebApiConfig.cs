using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using QuadWebApi.Infrastructure.IoC.NinjectWebApi;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.OData.Extensions;
namespace QuadWebApi
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Configure()
        {
            var config = new HttpConfiguration();
           
            /*config.Routes.MapHttpRoute(
          name: "BreezeApi",
          routeTemplate: "breeze/{controller}/{action}");

            config.Routes.MapHttpRoute(
                 name: "DefaultRoute",
                 routeTemplate: "api/v2/{controller}/{action}",
                 defaults: new { id = RouteParameter.Optional }
             );

            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{action}");
            */
            //Configure ninject resolver.
            config.DependencyResolver = new NinjectWebApiResolver(NinjectWebApiConfig.CreateKernel());

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            config.AddODataQueryFilter();

         

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

            // When returning JSON make sure that c# naming convention is translated to JavaScripts
            // i.e in c# a property may be called CargoType
            // but in javascript this needs to be cargoType
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            //var json = config.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            return config;
        }
    }
}
