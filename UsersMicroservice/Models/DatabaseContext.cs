using Microsoft.EntityFrameworkCore;

namespace UsersMicroservice.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string pwd = BCrypt.Net.BCrypt.HashPassword("Admin@1234");
            modelBuilder.Entity<User>().HasData(new User
            {
                Address = "12qwert1qed",
                Email = "admin@gmail.com",
                MobileNumber = "908764321",
                Name = "admin",
                Password = pwd,
                Role = "admin",
                UserId = -1
            });
        }

    }
}
