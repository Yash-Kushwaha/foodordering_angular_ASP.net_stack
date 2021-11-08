using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

namespace OrderFood_web_API.Models
{
    public class DatabaseContext
    {
        readonly MongoClient client;
        readonly IMongoDatabase db;
        public DatabaseContext(IConfiguration config)
        {
            var mongoenv = Environment.GetEnvironmentVariable("Mongo_DB");
            if (mongoenv == null)
            {
                mongoenv = config.GetConnectionString("MongoDBConnection");
            }
            client = new MongoClient(mongoenv);
            var dbname = Environment.GetEnvironmentVariable("DB_Name");

            if (dbname == null)
            {
                dbname = config.GetSection("MongoDatabase").Value;
            }
            db = client.GetDatabase(dbname);
        }
        public IMongoCollection<OrderFood> OrderFoods => db.GetCollection<OrderFood>("OrderFoods");
    }
}
