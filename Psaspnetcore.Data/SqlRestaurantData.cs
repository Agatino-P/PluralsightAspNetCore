using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Psapnetcore.Core;
using System.Collections.Generic;
using System.Linq;

namespace Psaspnetcore.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly PsancDbContext _context;

        public SqlRestaurantData(PsancDbContext context)
        {
            _context = context;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _context.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Restaurant Delete(int restaurantId)
        {
            var restaurant = GetById(restaurantId);
            if (restaurant != null)
            {
                _context.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurant GetById(int restaurantId)
        {
            return _context.Restaurants.Find(restaurantId);
        }

        public IEnumerable<Restaurant> GetByName(string partialName = null)
        {
            return _context.Restaurants.Where(r => string.IsNullOrWhiteSpace(partialName) || r.Name.Contains(partialName)).OrderBy(r => r.Name).ToList();
        }

        public int GetCountOfRestaurants()
        {
            return _context.Restaurants.Count();
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            EntityEntry<Restaurant> entity = _context.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
