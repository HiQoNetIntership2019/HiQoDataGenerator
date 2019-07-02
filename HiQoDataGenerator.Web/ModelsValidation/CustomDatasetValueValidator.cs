using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.Extensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class CustomDatasetValueValidator : AbstractValidator<CustomDatasetValueViewModel>
    {
        public CustomDatasetValueValidator()
        {
            string propertyName = "DatasetName";
            RuleFor(x => x.DatasetName)
                .MaximumLength(50).WithMessage(propertyName.MaximumLengthExceeded(50))
                .NotNull().WithMessage(propertyName.CanNotBeNull())
                .NotEmpty().WithMessage(propertyName.CanNotBeEmpty());

            propertyName = "Value";
            RuleFor(x => x.Value)
                .MaximumLength(150).WithMessage(propertyName.MaximumLengthExceeded(150))
                .NotNull().WithMessage(propertyName.CanNotBeNull())
                .NotEmpty().WithMessage(propertyName.CanNotBeEmpty());
        }
    }
}
