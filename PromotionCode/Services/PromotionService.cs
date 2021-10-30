using PromotionCode.Exceptions;
using PromotionCode.Models;
using PromotionCode.Repository;
using System.Collections.Generic;

namespace PromotionCode.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository repo;

        public PromotionService(IPromotionRepository repo)
        {
            this.repo = repo;
        }

        public string AddPromotion(PromotionCodes promotionCodes)
        {
            var obj = repo.GetPromotionCodesByID(promotionCodes.PromotionId);
            if (obj != null)
            {
                throw new PromotionAlreadyExistException("Promotion Already Exist");
            }
            return repo.AddPromotion(promotionCodes);
        }

        public string DeletePromotion(string Id)
        {
            var obj = repo.GetPromotionCodesByID(Id);
            if (obj == null)
            {
                throw new PromotionNotFoundException("Promotion does not Exist");
            }
            return repo.DeletePromotion(Id);
        }

        public List<PromotionCodes> GetPromotionCodes()
        {
            var obj = repo.GetPromotionCodes();
            if (obj == null && obj.Count == 0)
            {
                throw new PromotionNotFoundException("No promotion exist");
            }
            return obj;
        }

        public PromotionCodes GetPromotionCodesByID(string Id)
        {
            var obj = repo.GetPromotionCodesByID(Id);
            if (obj == null)
            {
                throw new PromotionNotFoundException("Promotion does not Exist");
            }
            return obj;
        }

        public string UpdatePromotion(string Id, PromotionCodes promotionCodes)
        {
            var obj = repo.GetPromotionCodesByID(Id);
            if (obj == null)
            {
                throw new PromotionNotFoundException("Promotion does not Exist");
            }
            return repo.UpdatePromotion(Id, promotionCodes);
        }
    }
}
