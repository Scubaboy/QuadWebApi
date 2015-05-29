using Breeze.ContextProvider;
using System.Collections.Generic;

namespace QuadWebApi.Infrastructure.Interfaces
{
    public interface IBreezeSaveEntitiesValidator
    {
        List<EntityInfo> Validate(List<EntityInfo> saveEntity);
    }
}
