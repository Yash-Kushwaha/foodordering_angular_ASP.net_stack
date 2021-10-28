using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Exceptions;
using RestaurantAPI.Models;
using RestaurantAPI.Service;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            try
            {
                return StatusCode(201, service.AddRestaurant(restaurant));
            }
            catch (RestaurantNotFoundException e)
            {
                return NotFound(e.Message);
            }

        }
        [HttpPost("fooditem")]
        public IActionResult PostRestaurant(FoodItem foodItem)
        {
            try
            {
                return StatusCode(201, service.AddFoodItemToRestaurant(foodItem.RestaurantName, foodItem));
            }
            catch (RestaurantNotFoundException e)
            {
                return Conflict(e.Message);
            }
            catch (FoodItemAlreadyExistException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetRestaurants()
        {
            try
            {
                return Ok(service.GetRestaurants());
            }
            catch (RestaurantNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
