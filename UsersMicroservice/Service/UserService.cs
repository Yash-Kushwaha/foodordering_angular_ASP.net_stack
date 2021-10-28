using System.Collections.Generic;
using UsersMicroservice.Exceptions;
using UsersMicroservice.Models;
using UsersMicroservice.Repository;

namespace UsersMicroservice.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repo;

        public UserService(IUserRepository repo)
        {
            this.repo = repo;
        }

        public string AddUser(User user)
        {
            var obj = repo.GetUserById(user.UserId);
            return obj == null ? repo.AddUser(user) : throw new UserAlreadyExistException($"{user.Name} with Id: {obj.UserId} Already Exist.");
        }

        public string DeleteUserById(int Id)
        {
            var obj = repo.GetUserById(Id);
            return obj != null ? repo.DeleteUserById(Id) : throw new UserNotFoundException($"user not found");
        }

        public List<User> GetAllUser()
        {
            var obj = repo.GetAllUser();
            if (obj != null && obj.Count > 0)
            {
                return obj;
            }
            else
            {
                throw new UserNotFoundException($"No Users Found");
            }
        }

        public User GetUserById(int Id)
        {
            var obj = repo.GetUserById(Id);
            return obj ?? throw new UserNotFoundException($"user not found");
        }

        public User LoginUser(User user)
        {
            var obj = repo.LoginUser(user);
            if (obj == null)
            {
                throw new UserNotFoundException($"user not Exist");
            }
            return obj;
        }

        public string UpdateUserById(int Id, User user)
        {
            var obj = repo.GetUserById(Id);
            return obj != null ? repo.UpdateUserById(Id, user) : throw new UserNotFoundException($"user not found");
        }
    }
}
