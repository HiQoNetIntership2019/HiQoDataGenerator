﻿using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Generators.Base;
using HiQoDataGenerator.GeneratorCore.Interfaces;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class DateGenerator : BaseDateGenerator
    {
        public DateGenerator(IRandomValuesGenerator randomValuesGenerator) : base(randomValuesGenerator) { }
        public override SupportedTypes FieldType => SupportedTypes.Date;
    }
}
