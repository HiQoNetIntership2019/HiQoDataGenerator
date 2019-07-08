﻿using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Interfaces
{
    public interface IFieldsGenerator
    {
        dynamic Generate(SupportedTypes type, IEnumerable<(ConstraintTypes type, dynamic value)> constraints, int? datasetId = null);
    }
}
