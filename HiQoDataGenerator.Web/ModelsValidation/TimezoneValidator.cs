using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class TimezoneValidator : AbstractValidator<TimezoneViewModel>
    {
        public TimezoneValidator()
        {
            RuleFor(x => x.Value)
                .MaximumLength(50)
                .NotNull()
                .NotEmpty();
        }
    }
}
