using System.Collections.Generic;
using UsersMicroservice.Models;

namespace UsersMicroservice.Service
{
    public interface IUserService
    {
        string AddUser(User user);
        User GetUserById(int Id);
        User GetUserByEmail(string Email);
        List<User> GetAllUser();
        string UpdateUserById(int Id, User user);
        string DeleteUserById(int Id);
        User LoginUser(string Email, string Password);
    }
}
