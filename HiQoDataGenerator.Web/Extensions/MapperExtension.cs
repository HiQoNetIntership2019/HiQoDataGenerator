﻿using AutoMapper;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Core.Entities;

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
                config.CreateMap<RegexViewModel, RegexModel>();
                config.CreateMap<RegexModel, RegexViewModel>();
                config.CreateMap<ConstraintViewModel, ConstraintModel>();
                config.CreateMap<ConstraintModel, ConstraintViewModel>();
            }).CreateMapper();
        }
    }

}
