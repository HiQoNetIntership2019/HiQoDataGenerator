using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.DataSetModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

            config.CreateMap<DatasetValueModel<string>, CountryDataset>()
                .ForMember(dist => dist.Name, opt => opt.MapFrom(src => src.Value));
            config.CreateMap<DbSet<CountryDataset>, DatasetValueModel<string>>()
                .ForMember(dist => dist.Value, opt => opt.MapFrom(src => src));

                   
            }).CreateMapper();
        }
    }
}
