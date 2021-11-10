using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult PostRestaurant(Restaurant restaurant)
        {
            return StatusCode(201, service.AddRestaurant(restaurant));
        }

        [HttpGet]
        [Authorize(Roles = "admin,customer")]
        public IActionResult GetRestaurants()
        {
            return Ok(service.GetRestaurants());
        }

        [Authorize(Roles = "admin,customer")]
        [HttpGet("{Name}")]
        public IActionResult GetRestaurants(string Name)
        {
            return Ok(service.GetRestaurant(Name));
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{Name}")]
        public IActionResult UpdateRestaurant(string Name, Restaurant restaurant)
        {
            return Ok(service.UpdateRestaurant(Name, restaurant));
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{Name}")]
        public IActionResult DeleteRestaurant(string Name)
        {
            return Ok(service.DeleteRestaurant(Name));
        }

        [Authorize(Roles = "admin")]
        [HttpPost("{RestaurantName}")]
        public IActionResult PostFood(string RestaurantName, FoodItem foodItem)
        {
            return StatusCode(201, service.AddFoodItemToRestaurant(RestaurantName, foodItem));
        }

        [Authorize(Roles = "admin,customer")]
        [HttpGet("foodItem/{RestaurantName}")]
        public IActionResult GetFoodItems(string RestaurantName)
        {
            return Ok(service.GetFoodItems(RestaurantName));
        }

        //[Authorize(Roles = "admin,customer")]
        //[HttpGet("{RestaurantName}/{FoodItemName}")]
        //public IActionResult GetFoodItem(string RestaurantName, string FoodItemName)
        //{
        //    return Ok(service.GetFoodItem(RestaurantName, FoodItemName));
        //}

        [Authorize(Roles = "admin")]
        [HttpDelete("{RestaurantName}/{FoodItemName}")]
        public IActionResult DeleteFoodItemFromRestaurant(string RestaurantName, string FoodItemName)
        {
            return Ok(service.DeleteFoodItemFromRestaurant(RestaurantName, FoodItemName));
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{RestaurantName}/{FoodItemName}")]
        public IActionResult UpdateFoodItemFromRestaurant(string RestaurantName, string FoodItemName, FoodItem foodItem)
        {
            return Ok(service.UpdateFoodItemFromRestaurant(RestaurantName, FoodItemName, foodItem));
        }

    }
}