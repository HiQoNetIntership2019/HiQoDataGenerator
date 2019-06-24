using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;

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
                config.CreateMap<Constraint, ConstraintModel>();

            }).CreateMapper();
        }
    }
}
