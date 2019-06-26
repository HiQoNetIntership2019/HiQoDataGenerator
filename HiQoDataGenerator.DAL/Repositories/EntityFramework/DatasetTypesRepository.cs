using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.DataSetModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class DatasetTypesRepository : BaseRepository<DatasetType>, IDatasetTypesRepository
    {
        public DatasetTypesRepository(DataContext context) : base(context) { }
    }
}
