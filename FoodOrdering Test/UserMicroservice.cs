using NUnit.Framework;
using UsersMicroservice.Models;
using UsersMicroservice.Repository;

namespace FoodOrdering_Test
{
    public class Tests
    {

        UserRepository userRepository;
        DatabaseContext db;
        [SetUp]
        public void Setup()
        {
            userRepository = new UserRepository(db);
        }

        [Test]
        public void Test1()
        {
            var users = userRepository.GetAllUser();
            Assert.NotNull(users);
        }
    }
}