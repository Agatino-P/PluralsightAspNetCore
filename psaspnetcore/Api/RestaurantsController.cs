using Microsoft.AspNetCore.Mvc;
using Psapnetcore.Core;
using Psaspnetcore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psaspnetcore.Api
{

    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData _restaurantData;
        private readonly PsancDbContext _context;

        public RestaurantsController( IRestaurantData restaurantData, PsancDbContext context)
        {
            _restaurantData = restaurantData;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _restaurantData.GetByName();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>  GetRestaurants(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var restaurant= await _context.FindAsync(typeof(Restaurant), id);

            if (restaurant == null)
                return NotFound();

            return Ok(restaurant);
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
