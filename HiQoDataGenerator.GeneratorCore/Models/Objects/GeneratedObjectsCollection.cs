using System.Collections;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Models.Objects
{
    public class GeneratedObjectsCollection : IEnumerable<List<GeneratedObject>>
    {
        private readonly Dictionary<string, List<GeneratedObject>> _collectionDict 
            = new Dictionary<string, List<GeneratedObject>>();


        public void Add(GeneratedObject generatedObject)
        {
            if (!_collectionDict.ContainsKey(generatedObject.Name))
            {
                _collectionDict[generatedObject.Name] = new List<GeneratedObject>();
            }
            _collectionDict[generatedObject.Name].Add(generatedObject);
        }

        public void AddRange(IEnumerable<GeneratedObject> generatedObjects)
        {
            foreach (var generatedObject in generatedObjects)
            {
                Add(generatedObject);
            }
        }
              
        public IEnumerator<List<GeneratedObject>> GetEnumerator()
        {
            foreach (var collection in _collectionDict)
            {
                yield return collection.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
