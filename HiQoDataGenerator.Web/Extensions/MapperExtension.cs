using AutoMapper;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Entities.Datasets;

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
                config.CreateMap<EncodingTypeViewModel, EncodingTypeModel>();
                config.CreateMap<EncodingTypeModel, EncodingTypeViewModel>();
                config.CreateMap<RegexViewModel, RegexModel>();
                config.CreateMap<RegexModel, RegexViewModel>();
                config.CreateMap<ConstraintViewModel, ConstraintModel>();
                config.CreateMap<ConstraintModel, ConstraintViewModel>();
                config.CreateMap<DateTimeFormatViewModel, DateTimeFormatModel>();
                config.CreateMap<DateTimeFormatModel, DateTimeFormatViewModel>();

                config.CreateMap<DatasetValueModel<string>, DatasetValueViewModel<string>>();
                config.CreateMap<DatasetValueViewModel<string>, DatasetValueModel<string>>();

                config.CreateMap<DatasetModel<string>, DatasetViewModel<string>>()
                    .ForMember(dist => dist.Values, opt => opt.MapFrom(src => src.Values));
                config.CreateMap<DatasetViewModel<string>, DatasetModel<string>>()
                    .ForMember(dist => dist.Values, opt => opt.MapFrom(src => src.Values));
            }).CreateMapper();
        }
    }

}
