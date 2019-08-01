using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<dynamic> GenerateMany(ICollection<dynamic> datasetValues)
        {
            var count = _randomizer.Number(1, datasetValues.Count - 1);
            return _randomizer.Shuffle(datasetValues).Take(count);
        }
    }
}
