using PromotionCode.Models;
using System.Collections.Generic;
using System.Linq;

namespace PromotionCode.Repository
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly Databasecontext db;

        public PromotionRepository(Databasecontext db)
        {
            this.db = db;
        }

        public string AddPromotion(PromotionCodes promotionCodes)
        {
            db.PromotionCodes.Add(promotionCodes);
            db.SaveChanges();
            return $"PromotionCode with id : {promotionCodes.PromotionId} generated with expiry date {promotionCodes.ExpiryDate}";
        }

        public string DeletePromotion(string Id)
        {
            var obj = db.PromotionCodes.Where(x => x.PromotionId == Id).FirstOrDefault();
            db.PromotionCodes.Remove(obj);
            db.SaveChanges();
            return $"PromotionCode with id : {obj.PromotionId} Deleted.";
        }

        public List<PromotionCodes> GetPromotionCodes()
        {
            return db.PromotionCodes.Where(x => true).ToList();
        }

        public PromotionCodes GetPromotionCodesByID(string Id)
        {
            return db.PromotionCodes.Where(x => x.PromotionId == Id).FirstOrDefault();
        }

        public string UpdatePromotion(string Id, PromotionCodes promotionCodes)
        {
            var obj = db.PromotionCodes.Where(x => x.PromotionId == Id).FirstOrDefault();
            obj.Discount = promotionCodes.Discount;
            obj.ExpiryDate = promotionCodes.ExpiryDate;
            obj.PromotionId = promotionCodes.PromotionId;
            obj.UseCount = promotionCodes.UseCount;
            db.Entry<PromotionCodes>(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return $"PromotionCode with id : {obj.PromotionId} Updated.";
        }
    }
}
