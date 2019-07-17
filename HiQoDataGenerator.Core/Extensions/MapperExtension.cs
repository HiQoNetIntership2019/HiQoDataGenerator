using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.DataSetModels;
using HiQoDataGenerator.DAL.Models.FileMetadataModels;
using HiQoDataGenerator.DAL.Models.GeneratedObjects;
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
                            new ConstraintModel(v.Constraint.Id, v.Constraint.Name, v.Constraint.Description, null, null))).ToList(),
                        i.DatasetId));

                config.CreateMap<FieldTypeModel, FieldType>().ReverseMap();

                config.CreateMap<Dataset, DatasetModel>();
                config.CreateMap<DatasetModel, DefinedDataset>()
                     .ForMember(c => c.Id, opt => opt.MapFrom(src => 0));
                config.CreateMap<CustomDatasetModel, Dataset>()
                    .ForMember(c => c.IsDefined, opt => opt.MapFrom(src => false))
                    .ForMember(c => c.Id, opt => opt.MapFrom(src => 0));
                config.CreateMap<DefinedDatasetModel, Dataset>()
                    .ForMember(c => c.IsDefined, opt => opt.MapFrom(src => true))
                    .ForMember(c => c.Id, opt => opt.MapFrom(src => 0));
                config.CreateMap<CustomDatasetValue, DefinedDatasetValue>()
                    .ForMember(c => c.DatasetId, opt => opt.MapFrom(src => 0))
                    .ForMember(c => c.Dataset, opt => opt.Ignore());

                config.CreateMap<CustomDatasetValue, DatasetValueModel>();
                config.CreateMap<DefinedDatasetValue, DatasetValueModel>();

                config.CreateMap<FileMetadata, FileMetadataModel>().ReverseMap();
                config.CreateMap<FileStatus, FileStatusModel>().ReverseMap();

                config.CreateMap<GeneratedFieldModel, CustomGeneratedField>().ReverseMap();
                config.CreateMap<GeneratedObjectModel, CustomGeneratedObject>().ReverseMap();


            }).CreateMapper();
        }
    }
}
