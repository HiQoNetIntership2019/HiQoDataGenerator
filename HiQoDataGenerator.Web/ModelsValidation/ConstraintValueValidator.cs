using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.Extensions;

using static HiQoDataGenerator.Web.Extensions.ValidationMessages;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class ConstraintValueValidator : AbstractValidator<ConstraintValueViewModel>
    {
        public ConstraintValueValidator()
        {
            string propertyName = "Value";
            RuleFor(x => x.Value)
                .MaximumLength(300).WithMessage(propertyName.MaximumLengthExceeded(300))
                .NotNull().WithMessage(propertyName.CanNotBeNull())
                .NotEmpty().WithMessage(propertyName.CanNotBeEmpty());

            propertyName = "ConstraintViewModel";
            RuleFor(x => x.ConstraintViewModel)
                .NotNull().WithMessage(propertyName.CanNotBeNull());
        }
    }
}
