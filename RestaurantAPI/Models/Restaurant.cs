using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace RestaurantAPI.Models
{
    public class Restaurant
    {
        [BsonId]
        public string Name { get; set; }
        public string[] Cuisine { get; set; }
        public float Rating { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public List<FoodItem> FoodItems { get; set; }
    }
}
