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
                config.CreateMap<TimezoneModel, Timezone>().ReverseMap();

                config.CreateMap<EncodingTypeModel, EncodingType>().ReverseMap();

                config.CreateMap<RegexModel, Regex>().ReverseMap();

                config.CreateMap<ConstraintModel, Constraint>().ReverseMap();

                config.CreateMap<DateTimeFormatModel, DateTimeFormat>().ReverseMap();

                config.CreateMap<ConfigurableObject, ConfigurableObjectModel>().ReverseMap();

                config.CreateMap<DatasetTypeModel, DatasetType>().ReverseMap();

                config.CreateMap<CustomDatasetModel, CustomDataset>().ReverseMap();

                config.CreateMap<CustomDatasetValue, CustomDatasetValueModel>().ReverseMap();

                config.CreateMap<ConstraintValueModel, ConstraintValue>()
                    .ForMember(dist => dist.Constraint, opt => opt.MapFrom(src => src.ConstraintType));
                config.CreateMap<ConstraintValue, ConstraintValueModel>()
                    .ForMember(dist => dist.ConstraintType, opt => opt.MapFrom(src => src.Constraint));

                config.CreateMap<DefinedDataset, DefinedDatasetModel>().ReverseMap();
                config.CreateMap<DefinedDatasetValue, DefinedDatasetValueModel>().ReverseMap();

                config.CreateMap<FieldModel, Field>()
                    .ForMember(dist => dist.ConstraintValues, opt => opt.MapFrom(src => src.Constraints));
                config.CreateMap<Field, FieldModel>()
                    .ConstructUsing(i => new FieldModel(i.Id, i.Name, i.IsRequired,
                        new FieldTypeModel(i.FieldType.Id, i.FieldType.Name),
                        i.ConstraintValues.Select(v => new ConstraintValueModel(v.Id, v.Value, 
                            new ConstraintModel(v.Constraint.Id, v.Constraint.Name, v.Constraint.Description, null, null))).ToList()));

                config.CreateMap<FieldTypeModel, FieldType>().ReverseMap();

            }).CreateMapper();
        }
    }
}
