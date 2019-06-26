using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Entities
{
    public class DatasetTypeModel : BaseModel
    {
        public string TypeName { get; }

        public DatasetTypeModel(int id, string typeName) : base(id) => TypeName = typeName;
    }
}
