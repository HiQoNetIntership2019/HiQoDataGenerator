using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class FieldValidator : AbstractValidator<FieldViewModel>
    {
        public FieldValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(150)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Constraints)
                .NotNull();

            RuleFor(x => x.FieldType)
                .NotNull();
        }
    }
}
