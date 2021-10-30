using System;

namespace PromotionCode.Exceptions
{
    public class PromotionNotFoundException : Exception
    {
        public PromotionNotFoundException()
        {

        }
        public PromotionNotFoundException(string Message) : base(Message)
        {

        }
    }
}
