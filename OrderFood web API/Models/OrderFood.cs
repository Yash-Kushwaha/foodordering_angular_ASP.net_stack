using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace OrderFood_web_API.Models
{
    public class OrderFood
    {
        [BsonId]
        public string OrderId { get; set; }
        public string PromotionCode { get; set; }
        public float TotalPrice { get; set; }
        public List<FoodItem> FoodItems { get; set; }
    }
}
