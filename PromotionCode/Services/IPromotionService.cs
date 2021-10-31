using PromotionCode.Models;
using System.Collections.Generic;

namespace PromotionCode.Services
{
    public interface IPromotionService
    {
        string AddPromotion(Models.PromotionCode promotionCodes);
        List<Models.PromotionCode> GetPromotionCodes();
        Models.PromotionCode GetPromotionCodesByID(string Id);
        string UpdatePromotion(string Id, Models.PromotionCode promotionCodes);
        string DeletePromotion(string Id);
    }
}
