using System;

namespace OrderFood_web_API.Exceptions
{
    public class OrderFoodNotFoundException : Exception
    {
        public OrderFoodNotFoundException()
        {

        }
        public OrderFoodNotFoundException(string Message) : base(Message)
        {

        }
    }
}
