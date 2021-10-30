using PromotionCode.Models;
using System.Collections.Generic;

namespace PromotionCode.Repository
{
    public interface IPromotionRepository
    {
        string AddPromotion(PromotionCodes promotionCodes);
        List<PromotionCodes> GetPromotionCodes();
        PromotionCodes GetPromotionCodesByID(string Id);
        string UpdatePromotion(string Id, PromotionCodes promotionCodes);
        string DeletePromotion(string Id);
    }
}
