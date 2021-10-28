using RestaurantAPI.Models;
using System.Collections.Generic;

namespace RestaurantAPI.Repository
{
    public interface IRestaurantRepository
    {
        string AddRestaurant(Restaurant restaurant);
        List<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(string Name);
        string UpdateRestaurant(string Name, Restaurant restaurant);
        string DeleteRestaurant(string Name);

        string AddFoodItemToRestaurant(string RestaurantName, FoodItem foodItem);
        List<FoodItem> GetFoodItems(string RestaurantName);
        FoodItem GetFoodItem(string RestaurantName, string FoodItemName);
        string DeleteFoodItemFromRestaurant(string RestaurantName, string FoodItemName);
        string UpdateFoodItemFromRestaurant(string RestaurantName, string FoodItemName, FoodItem foodItem);
    }
}