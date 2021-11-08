using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

namespace RestaurantAPI.Models
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
        public IMongoCollection<Restaurant> Restaurants => db.GetCollection<Restaurant>("Restaurants");
    }
}
