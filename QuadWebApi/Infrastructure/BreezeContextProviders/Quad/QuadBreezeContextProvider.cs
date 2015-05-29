using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using QuadWebApi.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuadWebApi.Infrastructure.BreezeContextProviders.Quad
{
    public class QuadBreezeContextProvider<T> : EFContextProvider<T>, IBreezeValidator where T : class,new()
    {
        private Dictionary<Type, IBreezeSaveEntitiesValidator> validators;

        public QuadBreezeContextProvider()
            : base()
        {
            this.validators = new Dictionary<Type, IBreezeSaveEntitiesValidator>();
        }

        /// <summary>
        /// Validate the saveMap based on supplied validation rules.
        /// </summary>
        /// <param name="saveMap">SaveMap to be validated.</param>
        /// <returns>Validated saveMap.</returns>
        protected override Dictionary<Type, List<EntityInfo>> BeforeSaveEntities(Dictionary<Type, List<EntityInfo>> saveMap)
        {
            var returnMap = saveMap;
            var changesToAdd = new Dictionary<Type, List<EntityInfo>>();

            foreach(var keyValuePiar in saveMap)
            {
                if (this.validators.ContainsKey(keyValuePiar.Key))
                {
                    changesToAdd[keyValuePiar.Key] = this.validators[keyValuePiar.Key].Validate(keyValuePiar.Value);
                }
            }

            foreach (var newValues in changesToAdd.Keys)
            {
                returnMap[newValues] = changesToAdd[newValues];
            }
                return returnMap;
        }

        public bool RegisterValidator(Type entityType, IBreezeSaveEntitiesValidator validator)
        {
            var addResult = false;

            if (!this.validators.ContainsKey(entityType))
            {
                this.validators.Add(entityType, validator);
                addResult = true;
            }

            return addResult;
        }
    }
}