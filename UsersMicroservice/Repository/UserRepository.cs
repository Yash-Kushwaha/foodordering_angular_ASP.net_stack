using System.Collections.Generic;
using System.Linq;
using UsersMicroservice.Models;

namespace UsersMicroservice.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext db;

        public UserRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public string AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return $"{user.Name} as {user.Role} is Added.";
        }

        public string DeleteUserById(int Id)
        {
            var user = db.Users.Where(x => x.UserId == Id).FirstOrDefault();
            db.Users.Remove(user);
            db.SaveChanges();
            return $"{user.Name} is Deleted.";
        }

        public List<User> GetAllUser()
        {
            return db.Users.Where(x => true).ToList();
        }

        public User GetUserByEmail(string Email)
        {
            return db.Users.Where(x => x.Email == Email).FirstOrDefault();
        }

        public User GetUserById(int Id)
        {
            return db.Users.Where(x => x.UserId == Id).FirstOrDefault();
        }

        public User LoginUser(string Email, string Password)
        {
            var usr = db.Users.Where(x => x.Email == Email).FirstOrDefault();
            if (usr == null || !BCrypt.Net.BCrypt.Verify(Password, usr.Password))
            {
                return null;
            }
            return usr;

        }

        public string UpdateUserById(int Id, User user)
        {
            var use = db.Users.Where(x => x.UserId == Id).FirstOrDefault();
            use.Address = user.Address;
            use.Email = user.Email;
            use.MobileNumber = use.MobileNumber;
            use.Name = user.Name;
            use.Password = user.Password;
            use.Role = user.Role;
            db.Entry<User>(use).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return $"{user.Name} is Updated.";
        }
    }
}
