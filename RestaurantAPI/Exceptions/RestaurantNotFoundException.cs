using System;

namespace RestaurantAPI.Exceptions
{
    public class RestaurantNotFoundException : Exception
    {
        public RestaurantNotFoundException() { }
        public RestaurantNotFoundException(string Message) : base(Message) { }
    }
}
