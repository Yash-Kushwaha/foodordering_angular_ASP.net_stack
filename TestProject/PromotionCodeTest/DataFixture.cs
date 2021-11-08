using Microsoft.EntityFrameworkCore;
using PromotionCode.Models;

namespace TestProject.PromotionCodeTest
{
    class DataFixture
    {
        public Databasecontext context;
        public DataFixture()
        {
            var options = new DbContextOptionsBuilder<Databasecontext>().UseInMemoryDatabase("PromotionCodeDB").Options;
            context = new Databasecontext(options);
        }
        public void Dispose()
        {
            context = null;
        }
    }
}
