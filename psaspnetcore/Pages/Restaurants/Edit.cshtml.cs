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
        public IActionResult OnGet(int? restaurantId)
        {
            if (restaurantId.HasValue)
            {
                Restaurant = _restaurantData.GetById(restaurantId.Value);
                if (Restaurant == null)
                {
                    return RedirectToPage("./NotFound");
                }
            }

            if (!restaurantId.HasValue)
            {
                Restaurant = new();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Restaurant.Id > 0)
            {
                Restaurant = _restaurantData.Update(Restaurant);
            }
            if (Restaurant.Id <= 0)
            {
                Restaurant = _restaurantData.Add(Restaurant);
            }
            _restaurantData.Commit();
            TempData["Message"] = "Restaurant saved";
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}

