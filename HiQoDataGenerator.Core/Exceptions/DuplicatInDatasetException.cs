using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Exceptions
{
    public class DuplicatInDatasetException : Exception
    {
        public DuplicatInDatasetException(string value, string datasetName) : base($"Value {value} already exsist in {datasetName}") { }
    }
}
