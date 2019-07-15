using HiQoDataGenerator.GeneratorCore.Interfaces;
using System.Collections.Generic;
using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Exceptions;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;

namespace HiQoDataGenerator.GeneratorCore.Generators
{
    public class FieldsGenerator : IFieldsGenerator
    {
        private readonly Dictionary<SupportedTypes, IFieldValueGenerator> _fieldsGenerators 
            = new Dictionary<SupportedTypes, IFieldValueGenerator>();

        private readonly IDatasetValueGenerator _datasetValueGenerator;

        public FieldsGenerator(IDatasetValueGenerator datasetValueGenerator, params IFieldValueGenerator[] valueGenerators)
        {
            _datasetValueGenerator = datasetValueGenerator;

            foreach (var valueGenerator in valueGenerators)
            {
                _fieldsGenerators[valueGenerator.FieldType] = valueGenerator;
            }
        }


        public dynamic Generate(SupportedTypes type, IEnumerable<ConstraintPrototype> constraints, DatasetPrototype datasetPrototype = null)
        { 
            if (datasetPrototype != null)
            {
                return _datasetValueGenerator.Generate(datasetPrototype.Values);
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
