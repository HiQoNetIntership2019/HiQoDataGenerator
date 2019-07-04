using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Infrastructure.ValidationExtensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class DateTimeFormatValidator : AbstractValidator<DateTimeFormatViewModel>
    {
        public DateTimeFormatValidator()
        {
            RuleFor(x => x.Value)
                .MaxLengthWithMessage(50)
                .CanNotBeNullWithMessage()
                .CanNotBeEmptyWithMessage();
        }
    }
}
