namespace Common.Exceptions
{
    using System;

    public class AuthenticateException : Exception
    {
        public AuthenticateException(string message) : base(message)
        { }
    }
}
