using HiQoDataGenerator.Web.ViewModels.Helpers;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Infrastructure.ValidationExtensions;
using FluentValidation;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class CustomDatasetValuesValidator : AbstractValidator<AddCustomDatasetValues>
    {
        public CustomDatasetValuesValidator()
        {
            RuleForEach(x => x.Values)
               .SetValidator(new CustomDatasetValueValidator());
        }
    }

    public class CustomDatasetValueValidator : AbstractValidator<CustomDatasetValueViewModel>
    {
        public CustomDatasetValueValidator()
        {
             RuleFor(x => x.Value)
                .MaxLengthWithMessage(150)
                .CanNotBeNullWithMessage()
                .CanNotBeEmptyWithMessage();
        }
    }
}
