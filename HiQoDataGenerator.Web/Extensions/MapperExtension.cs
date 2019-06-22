using AutoMapper;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Entities.Datasets;
using HiQoDataGenerator.Web.ViewModels.Dataset;
using System.Linq;

namespace HiQoDataGenerator.Web.Extensions
{
    public static class MapperExtension
    {
        public static IMapper GetMapper()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<TimezoneViewModel, TimezoneModel>();
                config.CreateMap<TimezoneModel, TimezoneViewModel>();
                config.CreateMap<FieldTypeViewModel, FieldTypeModel>();
                config.CreateMap<FieldTypeModel, FieldTypeViewModel>();

                config.CreateMap<string, DatasetValueModel<string>>()
                    .ForMember(dist => dist.Value, opt => opt.MapFrom(src => src));

                config.CreateMap<DatasetModel<string>, DatasetViewModel<string>>()
                    .ForMember(dest => dest.Values, opt => opt.MapFrom(src => src.Values.Select(val =>  new { val.Id, val.Value })));
                config.CreateMap<DatasetViewModel<string>, DatasetModel<string>>()
                    .ForMember(dest => dest.Values, opt => 
                        opt.MapFrom(src => src.Values.Select(val => 
                            new DatasetValueModel<string>(val.id, val.value))));


            }).CreateMapper();
        }
    }

}
