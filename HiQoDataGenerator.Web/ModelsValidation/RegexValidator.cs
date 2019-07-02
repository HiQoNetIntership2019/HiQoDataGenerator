using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.Extensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class RegexValidator : AbstractValidator<RegexViewModel>
    {
        public RegexValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(50).WithMessage("{PropertyName}".MaximumLengthExceeded(50))
                .NotNull().WithMessage("{PropertyName}".CanNotBeNull())
                .NotEmpty().WithMessage("{PropertyName}".CanNotBeEmpty());

            RuleFor(x => x.Value)
                .MaximumLength(300).WithMessage("{PropertyName}".MaximumLengthExceeded(300))
                .NotNull().WithMessage("{PropertyName}".CanNotBeNull())
                .NotEmpty().WithMessage("{PropertyName}".CanNotBeEmpty());
        }
    }
}
