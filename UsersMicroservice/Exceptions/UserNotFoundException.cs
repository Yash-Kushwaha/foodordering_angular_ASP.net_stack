using System;

namespace UsersMicroservice.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() { }
        public UserNotFoundException(string Message) : base(Message) { }
    }
}
