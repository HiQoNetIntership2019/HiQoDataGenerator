using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Infrastructure.ValidationExtensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
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
