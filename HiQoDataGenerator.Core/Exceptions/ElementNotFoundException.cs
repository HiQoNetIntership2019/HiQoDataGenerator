using System;

namespace HiQoDataGenerator.Core.Exceptions
{
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException(string message): base(message) { }
        public ElementNotFoundException() : base() { }
    }
}
