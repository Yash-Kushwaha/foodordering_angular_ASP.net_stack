using NUnit.Framework;
using PromotionCode.Repository;
using System.Collections.Generic;

namespace TestProject.PromotionCodeTest
{
    class PromotionCodeRepositoryTest
    {
        private readonly IPromotionRepository repo;
        public PromotionCodeRepositoryTest()
        {
            DataFixture fixture = new DataFixture();
            repo = new PromotionRepository(fixture.context);
        }

        [Test, Order(1)]
        public void AddPromotionShouldReturnString()
        {
            PromotionCode.Models.PromotionCode promotionCode = new PromotionCode.Models.PromotionCode() { Discount = 20, ExpiryDate = System.DateTime.Now.AddMonths(3), UseCount = 5 };
            var res = repo.AddPromotion(promotionCode);
            Assert.AreEqual("PromotionCode generated", res);
        }

        [Test, Order(2)]
        public void GetPromotionShouldReturnPromotionList()
        {
            var res = repo.GetPromotionCodes();
            Assert.IsAssignableFrom<List<PromotionCode.Models.PromotionCode>>(res);
        }

        [Test, Order(3)]
        public void GetPromotionByIdShouldReturnPromotion()
        {
            var list = repo.GetPromotionCodes();
            var res = repo.GetPromotionCodesByID(list[0].PromotionId);
            Assert.IsAssignableFrom<PromotionCode.Models.PromotionCode>(res);
        }

        [Test, Order(4)]
        public void UpdatePromotionShouldReturnString()
        {
            var list = repo.GetPromotionCodes();
            var res = repo.UpdatePromotion(list[0].PromotionId, list[0]);
            Assert.AreEqual("PromotionCode Updated.", res);
        }

        [Test, Order(5)]
        public void DeletePromotionShouldReturnString()
        {
            var list = repo.GetPromotionCodes();
            var res = repo.DeletePromotion(list[0].PromotionId);
            Assert.AreEqual("PromotionCode Deleted.", res);
        }
    }
}
