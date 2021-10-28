using System;
namespace RestaurantAPI.Exceptions
{
    public class FoodItemAlreadyExistException : Exception
    {
        public FoodItemAlreadyExistException() { }
        public FoodItemAlreadyExistException(string Message) : base(Message) { }
    }
}
