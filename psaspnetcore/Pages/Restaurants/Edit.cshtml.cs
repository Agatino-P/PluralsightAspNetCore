using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Psapnetcore.Core;
using Psaspnetcore.Data;
using System.Collections.Generic;

namespace psaspnetcore.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;

            Cuisines = _htmlHelper.GetEnumSelectList<Restaurant.CuisineType>();
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Restaurant = _restaurantData.Update(Restaurant);
                _restaurantData.Commit();
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
            }
            return Page();
        }
    }
}
