using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.DAL.Models.GeneratedObjects
{
    public class CustomGeneratedObject
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreation { get; set; }
        public IEnumerable<CustomGeneratedField> Fields { get; set; }
    }
}
