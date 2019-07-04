using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.IntermediateModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class FieldTypesConstraintsRepository : GenericRepository<FieldTypeConstraint>, IFieldTypesConstraintsRepository
    {
        public FieldTypesConstraintsRepository(DataContext context) : base(context) { }
    }
}
