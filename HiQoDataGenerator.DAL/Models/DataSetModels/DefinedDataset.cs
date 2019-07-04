﻿using HiQoDataGenerator.DAL.Models.CustomObjectModels;

namespace HiQoDataGenerator.DAL.Models.DataSetModels
{
    public class DefinedDataset : BaseModel
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public FieldType Type{ get; set; }
    }
}
