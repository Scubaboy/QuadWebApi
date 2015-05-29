using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadWebApi.Infrastructure.Interfaces
{
    internal interface IBreezeValidator
    {
        bool RegisterValidator(Type entityType, IBreezeSaveEntitiesValidator validator);
    }
}
