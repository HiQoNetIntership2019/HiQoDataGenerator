using HiQoDataGenerator.GeneratorCore.Interfaces;
using System;
using System.Collections.Generic;
using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Exceptions;

namespace HiQoDataGenerator.GeneratorCore.Generators
{
    public class FieldsGenerator : IFieldsGenerator
    {

        private readonly Dictionary<SupportedTypes, IFieldValueGenerator> _fieldsGenerators 
            = new Dictionary<SupportedTypes, IFieldValueGenerator>();


        public FieldsGenerator(params IFieldValueGenerator[] valueGenerators)
        {
            foreach (var valueGenerator in valueGenerators)
            {
                _fieldsGenerators[valueGenerator.GetFieldType()] = valueGenerator;
            }
        }


        public dynamic Generate(SupportedTypes type, IEnumerable<(ConstraintTypes type, dynamic value)> constraints, int? datasetId = null)
        { 
            if (datasetId != null)
            {
                throw new NotImplementedException();
            }
            try
            {
                return _fieldsGenerators[type].GenerateValue(constraints);
            }
            catch (ConstraintNotSupportedException ex)
            {
                ex.FieldId = (int)type;
                throw;
            }
        }
    }
}
