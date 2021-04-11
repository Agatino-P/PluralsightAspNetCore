using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Psapnetcore.Core;
using Psaspnetcore.Data;
using System.Collections.Generic;

namespace psaspnetcore.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IRestaurantData _restaurantData;

        public IEnumerable<Restaurant> Restaurants { get; set; }
        
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public string Message { get; set; }
        public ListModel(IConfiguration configuration, IRestaurantData restaurantData)
        {
            _configuration = configuration;
            _restaurantData = restaurantData;
        }
        public void OnGet()
        {
            Message = _configuration["Logging:LogLevel:Default"];
            Restaurants = _restaurantData.GetByName(SearchTerm);
        }
    }
}
