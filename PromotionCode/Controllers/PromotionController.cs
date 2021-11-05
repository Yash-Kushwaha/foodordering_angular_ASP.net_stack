using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromotionCode.Filters;
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

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult PostPromotion(Models.PromotionCode promotionCodes)
        {
            return Created("api/Prmotion", service.AddPromotion(promotionCodes));
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult GetAllPromotion()
        {
            return Ok(service.GetPromotionCodes());
        }

        [Authorize(Roles = "admin,customer")]
        [HttpGet("{Id}")]
        public IActionResult GetPromotionById(string Id)
        {
            return Ok(service.GetPromotionCodesByID(Id));
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{Id}")]
        public IActionResult UpdatePromotion(string Id, Models.PromotionCode promotionCodes)
        {
            return Ok(service.UpdatePromotion(Id, promotionCodes));
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{Id}")]
        public IActionResult DeletePromotion(string Id)
        {
            return Ok(service.DeletePromotion(Id));
        }

        [Authorize(Roles = "customer")]
        [HttpGet("use/{Id}")]
        public IActionResult UsePromotionCode(string Id)
        {
            return Ok(service.UsePromotionCode(Id));
        }
    }
}
