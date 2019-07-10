﻿using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Repositories.MongoDriver
{
    public abstract class MongoBaseRepository<T>

    {
        private readonly string _configSectionForConnectionString = "MongoConnection";
        private readonly string _databaseName = "DataGenerator";

        protected readonly IMongoCollection<T> _collection;

        public MongoBaseRepository(IConfiguration configuration, string collectionName)
        {
            _collection = new MongoClient(configuration.GetConnectionString(_configSectionForConnectionString))
                .GetDatabase(_databaseName)
                .GetCollection<T>(collectionName);
        }

        public IEnumerable<T> GetAll()
        {
            var collection = _collection.Find(model => true).ToList();
            return BsonSerializer.Deserialize<List<T>>(collection.ToJson());
        }

        public async Task AddAsync(T item)
        {
            await _collection.InsertOneAsync(item);
        }

        public async Task AddRangeAsync(IEnumerable<T> items)
        {
            await _collection.InsertManyAsync(items);
        }
    }
}