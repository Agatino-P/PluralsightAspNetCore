using Psapnetcore.Core;
using System;
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
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.AsReadOnly().OrderBy(r=>r.Name);            
        }
    }
}
