using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.GeneratedObjects;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace HiQoDataGenerator.DAL.Repositories.MongoDriver
{
    public class GeneratedObjectsRepository : MongoBaseRepository<CustomGeneratedObject>, IGeneratedObjectsRepository
    {
        private const string _collectionName = "GeneratedObjects";

        public GeneratedObjectsRepository(IConfiguration configuration) : base(configuration, _collectionName) { }

        public async Task<CustomGeneratedObject> GetByIdAsync(string id)
        {
            var result = await _collection.FindAsync(model => model.Id == ObjectId.Parse(id));
            return BsonSerializer.Deserialize<CustomGeneratedObject>(result.ToJson());
        }

        public async Task<bool> RemoveByIdAsync(string id)
        {
            return (await _collection.DeleteOneAsync(model => model.Id == ObjectId.Parse(id))).IsAcknowledged;
        }
    }
}
