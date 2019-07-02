using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.Extensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class FieldValidator : AbstractValidator<FieldViewModel>
    {
        public FieldValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(150).WithMessage("{PropertyName}".MaximumLengthExceeded(150))
                .NotNull().WithMessage("{PropertyName}".CanNotBeNull())
                .NotEmpty().WithMessage("{PropertyName}".CanNotBeEmpty());

            RuleFor(x => x.Constraints)
                .NotNull().WithMessage("{PropertyName}".CanNotBeNull());

            RuleForEach(x => x.Constraints)
                .SetValidator(new ConstraintValidator());

            RuleFor(x => x.FieldType)
                .NotNull().WithMessage("{PropertyName}".CanNotBeNull())
                .SetValidator(new FieldTypeValidator());
        }
    }
}
