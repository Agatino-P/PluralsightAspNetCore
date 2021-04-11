using Psapnetcore.Core;
using System.Collections.Generic;

namespace Psaspnetcore.Data
{
    public interface IRestaurantData
    {
        
         IEnumerable<Restaurant> GetByName(string partialName = null);
        Restaurant GetById(int restaurantId);
        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();
    }
}
