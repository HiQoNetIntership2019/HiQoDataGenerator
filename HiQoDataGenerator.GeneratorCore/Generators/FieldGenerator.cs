using HiQoDataGenerator.GeneratorCore.Interfaces;
using System;
using System.Collections.Generic;
using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Exceptions;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;

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
                _fieldsGenerators[valueGenerator.FieldType] = valueGenerator;
            }
        }


        public dynamic Generate(SupportedTypes type, IEnumerable<ConstraintPrototype> constraints, int? datasetId = null)
        { 
            if (datasetId != null)
            {
                throw new NotImplementedException();
            }
            try
            {
                return _fieldsGenerators[type].Generate(constraints);
            }
            catch (ConstraintNotSupportedException ex)
            {
                ex.FieldId = (int)type;
                throw;
            }
        }
    }
}
