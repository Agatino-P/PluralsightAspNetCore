using Microsoft.AspNetCore.Mvc;
using Psaspnetcore.Data;

namespace psaspnetcore.Pages.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData _restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            int numRestaurants = _restaurantData.GetCountOfRestaurants();
            return View(numRestaurants);
        }
    }



}
