using RestaurantAPI.Exceptions;
using RestaurantAPI.Models;
using RestaurantAPI.Repository;
using System.Collections.Generic;

namespace RestaurantAPI.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository repo;

        public RestaurantService(IRestaurantRepository repo)
        {
            this.repo = repo;
        }

        public string AddFoodItemToRestaurant(string RestaurantName, FoodItem foodItem)
        {
            Restaurant res = repo.GetRestaurant(RestaurantName);
            FoodItem foo = repo.GetFoodItem(RestaurantName, foodItem.Name);
            if (res == null)
            {
                throw new RestaurantNotFoundException("Restaurant does not exist");
            }
            else if (foo != null)
            {
                throw new FoodItemAlreadyExistException("FoodItem Already Exist");
            }
            return repo.AddFoodItemToRestaurant(RestaurantName, foodItem);
        }

        public string AddRestaurant(Restaurant restaurant)
        {
            Restaurant res = repo.GetRestaurant(restaurant.Name);
            if (res != null)
            {
                throw new RestaurantAlreadyExistException("Restaurant Already exist");
            }
            return repo.AddRestaurant(restaurant);
        }

        public string DeleteFoodItemFromRestaurant(string RestaurantName, string FoodItemName)
        {
            Restaurant res = repo.GetRestaurant(RestaurantName);
            FoodItem foo = repo.GetFoodItem(RestaurantName, FoodItemName);
            if (res == null)
            {
                throw new RestaurantNotFoundException("Restaurant does not exist");
            }
            else if (foo == null)
            {
                throw new FoodItemNotFoundException("FoodItem Not found");
            }
            return repo.DeleteFoodItemFromRestaurant(RestaurantName, FoodItemName);
        }

        public string DeleteRestaurant(string Name)
        {
            Restaurant res = repo.GetRestaurant(Name);
            if (res == null)
            {
                throw new RestaurantNotFoundException("Restaurant does not exist");
            }
            return repo.DeleteRestaurant(Name);
        }

        public FoodItem GetFoodItem(string RestaurantName, string FoodItemName)
        {
            Restaurant res = repo.GetRestaurant(RestaurantName);
            FoodItem foo = repo.GetFoodItem(RestaurantName, FoodItemName);
            if (res == null)
            {
                throw new RestaurantNotFoundException("Restaurant does not exist");
            }
            else if (foo == null)
            {
                throw new FoodItemNotFoundException("FoodItem Not found");
            }
            return foo;
        }

        public List<FoodItem> GetFoodItems(string RestaurantName)
        {
            List<FoodItem> foo = repo.GetFoodItems(RestaurantName);
            Restaurant res = repo.GetRestaurant(RestaurantName);
            if (res == null)
            {
                throw new RestaurantNotFoundException("Restaurant does not exist");
            }
            else if (foo == null && foo.Count == 0)
            {
                throw new FoodItemNotFoundException("FoodItem Not found");
            }
            return foo;
        }

        public Restaurant GetRestaurant(string Name)
        {
            Restaurant res = repo.GetRestaurant(Name);
            if (res == null)
            {
                throw new RestaurantNotFoundException("Restaurant does not exist");
            }
            return res;
        }

        public List<Restaurant> GetRestaurants()
        {
            List<Restaurant> obj = repo.GetRestaurants();
            if (obj == null && obj.Count == 0)
            {
                throw new RestaurantNotFoundException("Restaurants does not exist");
            }
            return obj;
        }

        public string UpdateFoodItemFromRestaurant(string RestaurantName, string FoodItemName, FoodItem foodItem)
        {
            Restaurant res = repo.GetRestaurant(RestaurantName);
            FoodItem foo = repo.GetFoodItem(RestaurantName, FoodItemName);
            if (res == null)
            {
                throw new RestaurantNotFoundException("Restaurant does not exist");
            }
            else if (foo == null)
            {
                throw new FoodItemNotFoundException("FoodItem Not found");
            }
            return repo.UpdateFoodItemFromRestaurant(RestaurantName, FoodItemName, foodItem);
        }

        public string UpdateRestaurant(string Name, Restaurant restaurant)
        {
            Restaurant res = repo.GetRestaurant(Name);
            if (res == null)
            {
                throw new RestaurantNotFoundException("Restaurant does not exist");
            }
            return repo.UpdateRestaurant(Name, restaurant);
        }
    }
}
