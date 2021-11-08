using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderFood_web_API.Filter;
using OrderFood_web_API.Models;
using OrderFood_web_API.Services;

namespace OrderFood_web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomExceptionFilter]
    public class OrderFoodController : ControllerBase
    {
        private readonly IOrderFoodService service;

        public OrderFoodController(IOrderFoodService service)
        {
            this.service = service;
        }
        [Authorize(Roles = "customer")]
        [HttpPost]
        public IActionResult PostOrderFood(OrderFood orderFood)
        {
            string authtoken = Request.Headers["Authorization"];
            string token = authtoken["Bearer ".Length..].Trim();
            return StatusCode(201, service.AddOrderFood(orderFood, token));
        }

        [HttpGet]
        [Authorize(Roles = "customer")]
        public IActionResult GetAllOrderFood()
        {
            return Ok(service.GetOrderFoods());
        }

        [HttpGet("{Id}")]
        [Authorize(Roles = "customer")]
        public IActionResult GetOrderFoodById(string Id)
        {
            return Ok(service.GetOrderFoodById(Id));
        }

        [HttpPut("{Id}")]
        [Authorize(Roles = "customer")]
        public IActionResult UpdateOrder(string Id, OrderFood orderFood)
        {
            return Ok(service.UpdateOrderFood(Id, orderFood));
        }

        [HttpDelete("{Id}")]
        [Authorize(Roles = "customer")]
        public IActionResult DeleteOrder(string Id)
        {
            return Ok(service.DeleteOrderFood(Id));
        }
    }
}
