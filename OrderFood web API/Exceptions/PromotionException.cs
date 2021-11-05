using System;

namespace OrderFood_web_API.Exceptions
{
    public class PromotionException : Exception
    {
        public PromotionException()
        {

        }
        public PromotionException(string Message) : base(Message)
        {

        }
    }
}
