using Psapnetcore.Core;
using System.Collections.Generic;

namespace Psaspnetcore.Data
{
    public interface IRestaurantData
    {
        
         IEnumerable<Restaurant> GetByName(string partialName = null);
    }
}
