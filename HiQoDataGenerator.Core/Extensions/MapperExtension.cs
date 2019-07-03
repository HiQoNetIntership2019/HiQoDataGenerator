using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.DataSetModels;
using System.Linq;

namespace HiQoDataGenerator.Core.Extensions
{
    public static class MapperExtension
    {
        public static IMapper GetMapper()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<TimezoneModel, Timezone>();
                config.CreateMap<Timezone, TimezoneModel>();
                config.CreateMap<FieldTypeModel, FieldType>();
                config.CreateMap<FieldType, FieldTypeModel>();
                config.CreateMap<EncodingTypeModel, EncodingType>();
                config.CreateMap<EncodingType, EncodingTypeModel>();
                config.CreateMap<RegexModel, Regex>();
                config.CreateMap<Regex, RegexModel>();
                config.CreateMap<ConstraintModel, Constraint>();
                config.CreateMap<Constraint, ConstraintModel>()
                    .ForMember(dest => dest.FieldTypes, opt => 
                        opt.MapFrom(item => item.SupportedTypes.Select(i => 
                            new FieldTypeModel(i.FieldType.Id, i.FieldType.Name))));

                config.CreateMap<DateTimeFormatModel, DateTimeFormat>();
                config.CreateMap<DateTimeFormat, DateTimeFormatModel>();    

                config.CreateMap<ConfigurableObject, ConfigurableObjectModel>();
                config.CreateMap<ConfigurableObjectModel, ConfigurableObject>();

                config.CreateMap<DatasetTypeModel, DatasetType>();
                config.CreateMap<DatasetType, DatasetTypeModel>();

                config.CreateMap<CustomDatasetModel, CustomDataset>();
                config.CreateMap<CustomDataset, CustomDatasetModel>();
                config.CreateMap<CustomDatasetValue, CustomDatasetValueModel>();
                config.CreateMap<CustomDatasetValueModel, CustomDatasetValue>();
                
                config.CreateMap<ConstraintValueModel, ConstraintValue>();
                config.CreateMap<ConstraintValue, ConstraintValueModel>();

                config.CreateMap<DefinedDataset, DefinedDatasetModel>();
                config.CreateMap<DefinedDatasetModel, DefinedDataset>();
                config.CreateMap<DefinedDatasetValue, DefinedDatasetValueModel>();
                config.CreateMap<DefinedDatasetValueModel, DefinedDatasetValue>();

                config.CreateMap<FieldModel, Field>();
                config.CreateMap<Field, FieldModel>();  
            }).CreateMapper();
        }
    }
}
