﻿namespace HiQoDataGenerator.Core.Entities
{
    public class CustomDatasetValueModel : BaseModel
    {
        public string Value { get; }

        public string DatasetName { get; }

        public CustomDatasetValueModel(int id, string value, CustomDatasetModel dataset) : base(id)
        {
            Value = value;
            DatasetName = dataset.Name;
        }
    }
}