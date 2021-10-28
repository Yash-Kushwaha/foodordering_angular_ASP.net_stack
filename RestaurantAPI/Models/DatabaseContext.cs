using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace RestaurantAPI.Models
{
    public class DatabaseContext
    {
        readonly MongoClient client;
        readonly IMongoDatabase db;
        public DatabaseContext(IConfiguration config)
        {
            client = new MongoClient(config.GetConnectionString("MongoDBConnection"));
            db = client.GetDatabase(config.GetSection("MongoDatabase").Value);
        }
        public IMongoCollection<Restaurant> Restaurants => db.GetCollection<Restaurant>("Restaurants");
    }
}
