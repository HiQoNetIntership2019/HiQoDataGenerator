using System;

namespace HiQoDataGenerator.Core.Exceptions
{
    public class ElementIsAlreadyExistException : Exception
    {
        public ElementIsAlreadyExistException(string message) : base(message) { }
        public ElementIsAlreadyExistException() : base() { }
    }
}
