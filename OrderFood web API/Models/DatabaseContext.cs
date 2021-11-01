using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace OrderFood_web_API.Models
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
        public IMongoCollection<OrderFood> OrderFoods => db.GetCollection<OrderFood>("OrderFoods");
    }
}
