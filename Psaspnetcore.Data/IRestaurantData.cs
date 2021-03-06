using Psapnetcore.Core;
using System.Collections.Generic;

namespace Psaspnetcore.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetByName(string partialName = null);
        Restaurant GetById(int restaurantId);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Delete(int restaurantId);
        int GetCountOfRestaurants();

        int Commit();
    }
}
