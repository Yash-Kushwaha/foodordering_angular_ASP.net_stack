using System;

namespace UsersMicroservice.Exceptions
{
    public class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException() { }
        public UserAlreadyExistException(string Message) : base(Message) { }
    }
}
