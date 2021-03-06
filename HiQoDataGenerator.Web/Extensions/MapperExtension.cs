﻿using AutoMapper;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Web.ViewModels.Helpers;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using System.Linq;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Models.Objects;

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

                config.CreateMap<ConfigurableObjectModel, ConfigurableObjectViewModel>();
                config.CreateMap<ConfigurableObjectViewModel, ConfigurableObjectModel>();

                config.CreateMap<DatasetTypeModel, DatasetTypeViewModel>();
                config.CreateMap<DatasetTypeViewModel, DatasetTypeModel>();

                config.CreateMap<CustomDatasetModel, CustomDatasetViewModel>();
                config.CreateMap<CustomDatasetViewModel, CustomDatasetModel>();
                config.CreateMap<CustomDatasetValueModel, CustomDatasetValueViewModel>();
                config.CreateMap<CustomDatasetValueViewModel, CustomDatasetValueModel>();
                config.CreateMap<AddCustomDatasetWithValues, CustomDatasetModel>();

                config.CreateMap<DefinedDatasetModel, DefinedDatasetViewModel>();
                config.CreateMap<DefinedDatasetViewModel, DefinedDatasetModel>();
                config.CreateMap<DefinedDatasetValueModel, DefinedDatasetValueViewModel>();
                config.CreateMap<DefinedDatasetValueViewModel, DefinedDatasetValueModel>();
                config.CreateMap<AddDefinedDatasetWithValues, DefinedDatasetModel>();

                config.CreateMap<ConstraintValueModel, ConstraintValueViewModel>();
                config.CreateMap<ConstraintValueViewModel, ConstraintValueModel>();

                config.CreateMap<FieldModel, FieldViewModel>();
                config.CreateMap<FieldViewModel, FieldModel>();

                config.CreateMap<DatasetModel, DatasetViewModel>();
                config.CreateMap<DatasetValueModel, DatasetValueViewModel>();

                config.CreateMap<ConfigurableObjectViewModel, ConfigurablePrototype>()
                    .ConstructUsing(o => new ConfigurablePrototype(o.Name, o.Fields.Select(f => 
                        new FieldPrototype(f.Name, f.IsRequired, (SupportedTypes)f.FieldType.Id, f.DatasetId, f.Constraints.Select(c => 
                            new ConstraintPrototype((ConstraintTypes) c.ConstraintType.Id, (object)c.Value))))));

                config.CreateMap<GeneratedField, GeneratedFieldViewModel>();

                config.CreateMap<GeneratedObject, GeneratedObjectViewModel>();
                config.CreateMap<GeneratedObjectViewModel, GeneratedObjectModel>()
                    .ConstructUsing(o => new GeneratedObjectModel(0, o.Name, o.DateCreated,
                        o.Fields.Select(f => new GeneratedFieldModel(0, f.Name, (object)f.Value))));

            }).CreateMapper();
        }
    }
}
