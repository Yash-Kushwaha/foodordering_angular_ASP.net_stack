using PromotionCode.Models;
using System;
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

        public string AddPromotion(Models.PromotionCode promotionCodes)
        {
            promotionCodes.PromotionId = DateTime.Now.Ticks.ToString("x");
            db.PromotionCode.Add(promotionCodes);
            db.SaveChanges();
            return $"PromotionCode generated";
        }

        public string DeletePromotion(string Id)
        {
            var obj = db.PromotionCode.Where(x => x.PromotionId == Id).FirstOrDefault();
            db.PromotionCode.Remove(obj);
            db.SaveChanges();
            return $"PromotionCode Deleted.";
        }

        public List<Models.PromotionCode> GetPromotionCodes()
        {
            return db.PromotionCode.Where(x => true).ToList();
        }

        public Models.PromotionCode GetPromotionCodesByID(string Id)
        {
            return db.PromotionCode.Where(x => x.PromotionId == Id).FirstOrDefault();
        }

        public string UpdatePromotion(string Id, Models.PromotionCode promotionCodes)
        {
            var obj = db.PromotionCode.Where(x => x.PromotionId == Id).FirstOrDefault();
            obj.Discount = promotionCodes.Discount;
            obj.ExpiryDate = promotionCodes.ExpiryDate;
            obj.PromotionId = promotionCodes.PromotionId;
            obj.UseCount = promotionCodes.UseCount;
            db.Entry<PromotionCode.Models.PromotionCode>(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return $"PromotionCode Updated.";
        }
    }
}
