using System.Collections.Generic;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using Bogus;

namespace HiQoDataGenerator.GeneratorCore.Generators
{
    public class DatasetValueGenerator : IDatasetValueGenerator
    {
        protected readonly Randomizer _randomizer;

        public DatasetValueGenerator()
        {
            _randomizer = new Randomizer();
        }

        public dynamic Generate(ICollection<dynamic> datasetValues)
        {
            return _randomizer.CollectionItem(datasetValues);
        }
    }
}
