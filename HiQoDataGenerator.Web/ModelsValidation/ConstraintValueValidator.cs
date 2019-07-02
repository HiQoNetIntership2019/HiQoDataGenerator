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
            RuleFor(x => x.Value)
                .MaximumLength(300).WithMessage("{PropertyName}".MaximumLengthExceeded(300))
                .NotNull().WithMessage("{PropertyName}".CanNotBeNull())
                .NotEmpty().WithMessage("{PropertyName}".CanNotBeEmpty());

            RuleFor(x => x.ConstraintViewModel)
                .NotNull().WithMessage("{PropertyName}".CanNotBeNull())
                .SetValidator(new ConstraintValidator());
        }
    }
}
