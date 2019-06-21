using System;

namespace HiQoDataGenerator.Core.Exceptions
{
    public class EmptyValueException : Exception
    {
        public EmptyValueException() : base("Property 'value' is empty") { } 
    }
}
