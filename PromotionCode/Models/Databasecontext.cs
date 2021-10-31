using Microsoft.EntityFrameworkCore;

namespace PromotionCode.Models
{
    public class Databasecontext : DbContext
    {
        public Databasecontext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<PromotionCode> PromotionCode { get; set; }
    }
}
