﻿namespace KM.Domain.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message): base (message) { }
    }
}
