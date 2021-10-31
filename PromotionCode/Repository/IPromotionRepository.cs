using PromotionCode.Models;
using System.Collections.Generic;

namespace PromotionCode.Repository
{
    public interface IPromotionRepository
    {
        string AddPromotion(Models.PromotionCode promotionCodes);
        List<Models.PromotionCode> GetPromotionCodes();
        Models.PromotionCode GetPromotionCodesByID(string Id);
        string UpdatePromotion(string Id, Models.PromotionCode promotionCodes);
        string DeletePromotion(string Id);
    }
}
