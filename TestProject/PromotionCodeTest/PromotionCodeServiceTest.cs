using NUnit.Framework;
using PromotionCode.Repository;
using PromotionCode.Services;

namespace TestProject.PromotionCodeTest
{
    class PromotionCodeServiceTest
    {
        private readonly IPromotionService service;
        private readonly IPromotionRepository repo;
        public PromotionCodeServiceTest()
        {
            DataFixture fixture = new DataFixture();
            repo = new PromotionRepository(fixture.context);
            this.service = new PromotionService(repo);
        }

        [Test, Order(1)]
        public void AddPromotionShouldReturnString()
        {
            PromotionCode.Models.PromotionCode promotionCode = new PromotionCode.Models.PromotionCode() { Discount = 20, ExpiryDate = System.DateTime.Now.AddMonths(3), UseCount = 5 };
            var res = service.AddPromotion(promotionCode);
            Assert.AreEqual("PromotionCode generated", res);
        }
    }
}
