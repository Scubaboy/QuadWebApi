using Breeze.ContextProvider;
using Breeze.WebApi2;

namespace QuadWebApi.Controllers.Breeze
{
    using Newtonsoft.Json.Linq;
    using QuadEntityFramework.DbContexts;
    using QuadEntityFramework.Entities;
    using QuadWebApi.Infrastructure.BreezeContextProviders.Quad;
    using QuadWebApi.Infrastructure.Interfaces;
    using System.Linq;
    using System.Web.Http;

    [RoutePrefix("breeze")]
    [BreezeController]
    public class BreezeController : ApiController
    {
        readonly QuadBreezeContextProvider<QuadDbContext> contextProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quadBreezeContext"></param>
        public BreezeController(IQuadBreezeContext<QuadDbContext> quadBreezeContext)
        {
            this.contextProvider = quadBreezeContext.ContextProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Metadata")]
        public string Metadata()
        {
            var meta = contextProvider.Metadata();
            return meta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ActiveQuads")]
        public IQueryable<ActiveQuadEntity> Quads()
        {
            return this.contextProvider.Context.Quads;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveBundle"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveActiveQuadChanges")]
        public SaveResult SaveActiveQuadChanges(JObject saveBundle)
        {
            var saveResult = contextProvider.SaveChanges(saveBundle);
            return saveResult;
        }
    }
}