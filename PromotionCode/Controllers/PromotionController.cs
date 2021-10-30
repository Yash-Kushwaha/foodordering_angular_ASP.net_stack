using Microsoft.AspNetCore.Mvc;
using PromotionCode.Filters;
using PromotionCode.Models;
using PromotionCode.Services;

namespace PromotionCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomExceptionFilter]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService service;

        public PromotionController(IPromotionService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult PostPromotion(PromotionCodes promotionCodes)
        {
            return Created("api/Prmotion", service.AddPromotion(promotionCodes));
        }
        [HttpGet]
        public IActionResult GetAllPromotion()
        {
            return Ok(service.GetPromotionCodes());
        }

        [HttpGet("{Id}")]
        public IActionResult GetPromotionById(string Id)
        {
            return Ok(service.GetPromotionCodesByID(Id));
        }
    }
}
