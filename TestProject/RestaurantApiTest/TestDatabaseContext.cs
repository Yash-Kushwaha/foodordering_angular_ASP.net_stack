using MongoDB.Driver;

namespace TestProject.RestaurantApiTest
{
    class TestDatabaseContext
    {
        readonly MongoClient client;
        readonly IMongoDatabase db;
        public TestDatabaseContext()
        {
            client = new MongoClient("mongodb://localhost:27017/");
            db = client.GetDatabase("TestRestaurantDB");
        }
        public IMongoCollection<RestaurantAPI.Models.Restaurant> Restaurants => db.GetCollection<RestaurantAPI.Models.Restaurant>("Restaurants");
    }
}
