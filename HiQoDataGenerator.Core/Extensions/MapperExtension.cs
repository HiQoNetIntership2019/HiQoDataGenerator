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
                config.CreateMap<RegexModel, Regex>();
                config.CreateMap<Regex, RegexModel>();
            }).CreateMapper();
        }
    }
}
