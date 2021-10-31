using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Filters;
using RestaurantAPI.Models;
using RestaurantAPI.Service;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [CustomExceptionFilter]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService service;
        public RestaurantController(IRestaurantService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult PostRestaurant(Restaurant restaurant)
        {
            return StatusCode(201, service.AddRestaurant(restaurant));
        }

        [HttpGet]
        // [Authorize(Roles = "customer")]
        public IActionResult GetRestaurants()
        {
            return Ok(service.GetRestaurants());
        }
        [HttpGet("{Name}")]
        public IActionResult GetRestaurants(string Name)
        {
            return Ok(service.GetRestaurant(Name));
        }

        [HttpPut("{Name}")]
        public IActionResult UpdateRestaurant(string Name, Restaurant restaurant)
        {
            return Ok(service.UpdateRestaurant(Name, restaurant));
        }

        [HttpDelete("{Name}")]
        public IActionResult DeleteRestaurant(string Name)
        {
            return Ok(service.DeleteRestaurant(Name));
        }

        /*
        string AddFoodItemToRestaurant(string RestaurantName, FoodItem foodItem);
        List<FoodItem> GetFoodItems(string RestaurantName);
        FoodItem GetFoodItem(string RestaurantName, string FoodItemName);
        string DeleteFoodItemFromRestaurant(string RestaurantName, string FoodItemName);
        string UpdateFoodItemFromRestaurant(string RestaurantName, string FoodItemName, FoodItem foodItem);
         */

        [HttpPost("{RestaurantName}")]
        public IActionResult PostFood(string RestaurantName, FoodItem foodItem)
        {
            return StatusCode(201, service.AddFoodItemToRestaurant(foodItem.RestaurantName, foodItem));
        }
        [HttpGet("foodItem/{RestaurantName}")]
        public IActionResult GetFoodItems(string RestaurantName)
        {
            return Ok(service.GetFoodItems(RestaurantName));
        }
        [HttpGet("{RestaurantName}/{FoodItemName}")]
        public IActionResult GetFoodItem(string RestaurantName, string FoodItemName)
        {
            return Ok(service.GetFoodItem(RestaurantName, FoodItemName));
        }
        [HttpDelete("{RestaurantName}/{FoodItemName}")]
        public IActionResult DeleteFoodItemFromRestaurant(string RestaurantName, string FoodItemName)
        {
            return Ok(service.DeleteFoodItemFromRestaurant(RestaurantName, FoodItemName));
        }
        [HttpPut("{RestaurantName}/{FoodItemName}")]
        public IActionResult UpdateFoodItemFromRestaurant(string RestaurantName, string FoodItemName, FoodItem foodItem)
        {
            return Ok(service.UpdateFoodItemFromRestaurant(RestaurantName, FoodItemName, foodItem));
        }

    }
}