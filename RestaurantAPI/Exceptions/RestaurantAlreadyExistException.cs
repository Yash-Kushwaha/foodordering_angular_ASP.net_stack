using System;

namespace RestaurantAPI.Exceptions
{
    public class RestaurantAlreadyExistException : Exception
    {
        public RestaurantAlreadyExistException() { }
        public RestaurantAlreadyExistException(string Message) : base(Message) { }
    }
}
