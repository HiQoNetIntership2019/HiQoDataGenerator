using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Exceptions
{
    public class DatasetNotFoundException : Exception
    {
        public DatasetNotFoundException(string datasetName) : base($"Dataset with name {datasetName} not found") { }
    }
}
