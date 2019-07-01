using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.Extensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class RegexValidator : AbstractValidator<RegexViewModel>
    {
        public RegexValidator()
        {
            string propertyName = "Name";
            RuleFor(x => x.Name)
                .MaximumLength(50).WithMessage(propertyName.MaximumLengthExceeded(50))
                .NotNull().WithMessage(propertyName.CanNotBeNull())
                .NotEmpty().WithMessage(propertyName.CanNotBeEmpty());

            propertyName = "Value";
            RuleFor(x => x.Value)
                .MaximumLength(300).WithMessage(propertyName.MaximumLengthExceeded(300))
                .NotNull().WithMessage(propertyName.CanNotBeNull())
                .NotEmpty().WithMessage(propertyName.CanNotBeEmpty());
        }
    }
}
