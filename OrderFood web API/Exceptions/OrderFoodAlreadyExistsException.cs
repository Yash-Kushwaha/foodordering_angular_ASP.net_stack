using System;

namespace OrderFood_web_API.Exceptions
{
    public class OrderFoodAlreadyExistsException : Exception
    {
        public OrderFoodAlreadyExistsException()
        {

        }
        public OrderFoodAlreadyExistsException(string Message) : base(Message)
        {

        }
    }
}
