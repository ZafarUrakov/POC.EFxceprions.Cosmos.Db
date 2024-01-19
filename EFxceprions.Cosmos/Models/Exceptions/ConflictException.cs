using System;

namespace EFxceptions.Cosmos.Models.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message) { }
    }
}
