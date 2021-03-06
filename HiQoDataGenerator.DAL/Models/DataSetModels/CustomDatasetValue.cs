﻿namespace HiQoDataGenerator.DAL.Models.DataSetModels
{
    public class CustomDatasetValue : BaseModel
    {
        public string Value { get; set; }

        public int DatasetId { get; set; }
        public virtual CustomDataset Dataset { get; set; }
    }
}
