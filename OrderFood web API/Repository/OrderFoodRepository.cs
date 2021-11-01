using MongoDB.Driver;
using OrderFood_web_API.Models;
using OrderFood_web_API.Services;
using System.Collections.Generic;
using System.Linq;

namespace OrderFood_web_API.Repository
{
    public class OrderFoodRepository : IOrderFoodRepository
    {
        private readonly DatabaseContext db;

        public OrderFoodRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public string AddOrderFood(OrderFood orderFood)
        {
            
            db.OrderFoods.InsertOne(orderFood);
            return $"Order made successfully";
        }

        public string DeleteOrderFood(string Id)
        {
            db.OrderFoods.DeleteOne(x => x.OrderId == Id);
            return $"Order placed";
        }

        public OrderFood GetOrderFoodById(string Id)
        {
            return db.OrderFoods.Find(x => x.OrderId == Id).FirstOrDefault();
        }

        public List<OrderFood> GetOrderFoods()
        {
            return db.OrderFoods.Find(x => true).ToList();
        }

        public string UpdateOrderFood(string Id, OrderFood orderFood)
        {
            var filter = Builders<OrderFood>.Filter.Where(x => x.OrderId == Id);
            var update = Builders<OrderFood>.Update
                .Set(x => x.FoodItems, orderFood.FoodItems)
                .Set(x => x.OrderId, orderFood.OrderId)
                .Set(x => x.PromotionCode, orderFood.PromotionCode)
                .Set(x => x.TotalPrice, orderFood.TotalPrice);
            db.OrderFoods.UpdateOne(filter, update);
            return $"order updated";
        }
    }
}
