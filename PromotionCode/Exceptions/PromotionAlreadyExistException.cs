using System;

namespace PromotionCode.Exceptions
{
    public class PromotionAlreadyExistException : Exception
    {
        public PromotionAlreadyExistException()
        {

        }
        public PromotionAlreadyExistException(string Message) : base(Message)
        {

        }
    }
}
