using NUnit.Framework;
using System.Collections.Generic;
using UsersMicroservice.Models;
using UsersMicroservice.Repository;

namespace TestProject.UserMicroservice
{
    class UserRepositoryTest
    {
        private readonly IUserRepository repo;
        public UserRepositoryTest()
        {
            DatabaseFixture fixture = new DatabaseFixture();
            repo = new UserRepository(fixture.context);
        }

        [Test, Order(1)]
        public void AddUserShouldReturnString()
        {
            var res = repo.AddUser(new User() { Address = "123qwweerty", Email = "Kush@gmail.com", MobileNumber = "9087654321", Name = "Kush", Password = "Kush@1234", Role = "customer", UserId = 1 });
            Assert.AreEqual("Kush as customer is Added.", res);
        }

        [Test, Order(2)]
        public void GetAllUserShouldReturnList()
        {
            var res = repo.GetAllUser();
            Assert.IsAssignableFrom<List<User>>(res);
        }

        [Test, Order(3)]
        public void GetUserByIdShouldReturnUser()
        {
            var res = repo.GetUserById(1);
            Assert.AreEqual("Kush", res.Name);
        }

        [Test, Order(4)]
        public void UpdateUserByIdShouldReturnString()
        {
            User user = new User() { Address = "123qwweerty", Email = "Kush@hotmail.com", MobileNumber = "9087654321", Name = "Kush", Password = "Kush@1234", Role = "customer", UserId = 1 };
            var res = repo.UpdateUserById(1, user);
            Assert.AreEqual("Kush is Updated.", res);
        }

        [Test]
        public void DeleteUserByIdShouldReturnString()
        {
            var res = repo.DeleteUserById(1);
            Assert.AreEqual("Kush is Deleted.", res);
        }
    }
}
