using System;

namespace RestaurantAPI.Exceptions
{
    public class FoodItemNotFoundException : Exception
    {
        public FoodItemNotFoundException() { }
        public FoodItemNotFoundException(string message) : base(message) { }
    }
}
