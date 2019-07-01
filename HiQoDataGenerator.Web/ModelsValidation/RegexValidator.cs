using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class RegexValidator : AbstractValidator<RegexViewModel>
    {
        public RegexValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(50)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Value)
                .MaximumLength(300)
                .NotNull()
                .NotEmpty();
        }
    }
}
