using Microsoft.EntityFrameworkCore;

namespace PromotionCode.Models
{
    public class Databasecontext : DbContext
    {
        public Databasecontext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<PromotionCodes> PromotionCodes { get; set; }
    }
}
