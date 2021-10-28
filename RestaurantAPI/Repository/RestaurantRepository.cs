using MongoDB.Driver;
using RestaurantAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly DatabaseContext db;
        public RestaurantRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public string AddFoodItemToRestaurant(string RestaurantName, FoodItem foodItem)
        {
            var obj = db.Restaurants.Find(x => x.Name == RestaurantName).FirstOrDefault();
            obj.FoodItems.Add(foodItem);
            var filter = Builders<Restaurant>.Filter.Where(x => x.Name == obj.Name);
            db.Restaurants.FindOneAndReplace(filter, obj);
            return $"{foodItem.Name} Added to {obj.Name}";
        }

        public string AddRestaurant(Restaurant restaurant)
        {
            db.Restaurants.InsertOne(restaurant);
            return $"{restaurant.Name} Added";
        }

        public string DeleteFoodItemFromRestaurant(string RestaurantName, string FoodItemName)
        {
            var obj = db.Restaurants.Find(x => x.Name == RestaurantName).FirstOrDefault();
            obj.FoodItems.RemoveAll(x => x.Name == FoodItemName);
            var filter = Builders<Restaurant>.Filter.Where(x => x.Name == obj.Name);
            db.Restaurants.FindOneAndReplace(filter, obj);

            return $"{FoodItemName} deleted from {RestaurantName}";
        }

        public string DeleteRestaurant(string Name)
        {
            db.Restaurants.DeleteOne(x => x.Name == Name);
            return $"{Name} deleted";
        }

        public FoodItem GetFoodItem(string RestaurantName, string FoodItemName)
        {
            return db.Restaurants.Find(x => x.Name == RestaurantName).FirstOrDefault().FoodItems.Where(x => x.Name == FoodItemName).FirstOrDefault();
        }

        public List<FoodItem> GetFoodItems(string RestaurantName)
        {
            return db.Restaurants.Find(x => x.Name == RestaurantName).FirstOrDefault().FoodItems;
        }

        public Restaurant GetRestaurant(string Name)
        {
            return db.Restaurants.Find(x => x.Name == Name).FirstOrDefault();
        }

        public List<Restaurant> GetRestaurants()
        {
            return db.Restaurants.Find(x => true).ToList();
        }

        public string UpdateFoodItemFromRestaurant(string RestaurantName, string FoodItemName, FoodItem foodItem)
        {
            var rest = db.Restaurants.Find(x => x.Name == RestaurantName).FirstOrDefault();
            var item = db.Restaurants.Find(x => x.Name == RestaurantName).FirstOrDefault().FoodItems;
            int indexOfFoodItem = item.FindIndex(x => x.Name == FoodItemName);
            item[indexOfFoodItem] = foodItem;
            var filter = Builders<Restaurant>.Filter.Where(x => x.Name == RestaurantName);
            var update = Builders<Restaurant>.Update
                .Set(x => x.About, rest.About)
                .Set(x => x.Address, rest.Address)
                .Set(x => x.Cuisine, rest.Cuisine)
                .Set(x => x.Rating, rest.Rating)
                .Set(x => x.Name, rest.Name)
                .Set(x => x.FoodItems, item);

            db.Restaurants.UpdateOne(filter, update);
            return $"{foodItem.Name} Updated";
        }

        public string UpdateRestaurant(string Name, Restaurant restaurant)
        {
            var filter = Builders<Restaurant>.Filter.Where(x => x.Name == Name);
            var update = Builders<Restaurant>.Update
                .Set(x => x.About, restaurant.About)
                .Set(x => x.Address, restaurant.Address)
                .Set(x => x.Cuisine, restaurant.Cuisine)
                .Set(x => x.Rating, restaurant.Rating)
                .Set(x => x.Name, restaurant.Name)
                .Set(x => x.FoodItems, restaurant.FoodItems);

            db.Restaurants.UpdateOne(filter, update);
            return $"{restaurant.Name} Updated";
        }
    }
}
