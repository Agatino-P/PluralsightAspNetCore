using Psapnetcore.Core;
using System.Collections.Generic;
using System.Linq;

namespace Psaspnetcore.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {

            _restaurants = new()
            {
                new Restaurant { Id = 1, Name = "Scott", Location = "Maryland", Cuisine = Restaurant.CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Cinnamon", Location = "London", Cuisine = Restaurant.CuisineType.Indian },
                new Restaurant { Id = 3, Name = "La Costa", Location = "California", Cuisine = Restaurant.CuisineType.Mexican }
            };

        }

        public Restaurant GetById(int restaurantId)
        {
            return _restaurants.SingleOrDefault(r => r.Id == restaurantId);
        }

        public IEnumerable<Restaurant> GetByName(string partialName = null)
        {
            return _restaurants.AsReadOnly()
                .Where(r => string.IsNullOrWhiteSpace(partialName) || r.Name.Contains(partialName))
                .OrderBy(r => r.Name);
        }


        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            Restaurant existing = _restaurants.FirstOrDefault(r => r.Id == updatedRestaurant.Id);
            if (existing != null)
            {
                existing.Name = updatedRestaurant.Name;
                existing.Location = updatedRestaurant.Location;
                existing.Cuisine = updatedRestaurant.Cuisine;
            }
            return existing;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int restaurantId)
        {
            var restaurant = _restaurants.FirstOrDefault(r => r.Id == restaurantId);
            if (restaurant != null)
            {
                _restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return _restaurants.Count;
        }
    }
}
