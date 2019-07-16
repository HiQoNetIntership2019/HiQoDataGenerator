using System;
using System.Collections.Generic;

namespace HiQoDataGenerator.Core.Entities
{
    public class GeneratedObjectModel : BaseModel
    {
        public string Name { get; }
        public DateTime DateCreation { get; }
        public IEnumerable<GeneratedFieldModel> Fields { get; }

        public GeneratedObjectModel(int id, string name, DateTime dateCreation, IEnumerable<GeneratedFieldModel> fields) :
            base(id)
        {
            Name = name;
            DateCreation = dateCreation;
            Fields = fields;
        }
    }
}
