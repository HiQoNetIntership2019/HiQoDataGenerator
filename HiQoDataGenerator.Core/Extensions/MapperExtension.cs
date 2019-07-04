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

                config.CreateMap<EncodingTypeModel, EncodingType>();
                config.CreateMap<EncodingType, EncodingTypeModel>();

                config.CreateMap<RegexModel, Regex>();
                config.CreateMap<Regex, RegexModel>();

                config.CreateMap<ConstraintModel, Constraint>();
                config.CreateMap<Constraint, ConstraintModel>();

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

                config.CreateMap<ConstraintValueModel, ConstraintValue>()
                    .ForMember(dist => dist.Constraint, opt => opt.MapFrom(src => src.ConstraintType));
                config.CreateMap<ConstraintValue, ConstraintValueModel>()
                    .ForMember(dist => dist.ConstraintType, opt => opt.MapFrom(src => src.Constraint));

                config.CreateMap<DefinedDataset, DefinedDatasetModel>();
                config.CreateMap<DefinedDatasetModel, DefinedDataset>();
                config.CreateMap<DefinedDatasetValue, DefinedDatasetValueModel>();
                config.CreateMap<DefinedDatasetValueModel, DefinedDatasetValue>();

                config.CreateMap<FieldModel, Field>()
                    .ForMember(dist => dist.ConstraintValues, opt => opt.MapFrom(src => src.Constraints));
                config.CreateMap<Field, FieldModel>()
                    .ConstructUsing(i => new FieldModel(i.Id, i.Name, i.IsRequired,
                        new FieldTypeModel(i.FieldType.Id, i.FieldType.Name),
                        i.ConstraintValues.Select(v => new ConstraintValueModel(v.Id, v.Value, 
                            new ConstraintModel(v.Constraint.Id, v.Constraint.Name, v.Constraint.Description, null, null))).ToList()));

                config.CreateMap<FieldTypeModel, FieldType>();
                config.CreateMap<FieldType, FieldTypeModel>();

            }).CreateMapper();
        }
    }
}
