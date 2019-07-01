using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class DateTimeFormatValidator : AbstractValidator<DateTimeFormatViewModel>
    {
        public DateTimeFormatValidator()
        {
            RuleFor(x => x.Value)
                .MaximumLength(50)
                .NotNull()
                .NotEmpty();
        }
    }
}
