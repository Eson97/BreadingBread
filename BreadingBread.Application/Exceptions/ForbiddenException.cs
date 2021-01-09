using System;

namespace BreadingBread.Application.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException(string message) : base(message)
        {

        }
    }
}
