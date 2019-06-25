using System;

namespace HiQoDataGenerator.Core.Exceptions
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string message): base(message) { }
        public InvalidDataException() : base() { }
    }
}
