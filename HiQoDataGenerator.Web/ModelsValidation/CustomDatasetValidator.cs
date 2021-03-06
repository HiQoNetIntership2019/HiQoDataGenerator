﻿using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.ViewModels.Helpers;
using HiQoDataGenerator.Infrastructure.ValidationExtensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class CustomDatasetValidator : AbstractValidator<CustomDatasetViewModel>
    {
        public CustomDatasetValidator()
        {
            RuleFor(x => x.Name)
                .MaxLengthWithMessage(50)
                .CanNotBeNullWithMessage()
                .CanNotBeEmptyWithMessage();
        }
    }

    public class CustomDatasetWithValuesValidator : AbstractValidator<AddCustomDatasetWithValues>
    {
        public CustomDatasetWithValuesValidator()
        {
            RuleFor(x => x.Name)
                .MaxLengthWithMessage(50)
                .CanNotBeNullWithMessage()
                .CanNotBeEmptyWithMessage();

            RuleForEach(x => x.Values)
                .SetValidator(new CustomDatasetValueValidator());
        }
    }
}
