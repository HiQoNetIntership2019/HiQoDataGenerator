using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.Extensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class CustomDatasetValueValidator : AbstractValidator<CustomDatasetValueViewModel>
    {
        public CustomDatasetValueValidator()
        {
            RuleFor(x => x.Value)
                .MaximumLength(150).WithMessage("{PropertyName}".MaximumLengthExceeded(150))
                .NotNull().WithMessage("{PropertyName}".CanNotBeNull())
                .NotEmpty().WithMessage("{PropertyName}".CanNotBeEmpty());
        }
    }
}
