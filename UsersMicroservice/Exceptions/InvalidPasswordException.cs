using System;

namespace UsersMicroservice.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException() { }
        public InvalidPasswordException(string Message) : base(Message) { }
    }
}
