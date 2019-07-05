using System;

namespace HiQoDataGenerator.GeneratorCore.Exceptions
{
    public class NegativeCountObjectsException : Exception
    {
        public NegativeCountObjectsException() : base("Count objects can not be negative") { }
    }
}
