using FluentValidation;
using HiQoDataGenerator.Infrastructure.ValidationExtensions;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class TimezoneValidator : AbstractValidator<TimezoneViewModel>
    {
        public TimezoneValidator()
        {
            RuleFor(x => x.Value)
                .MaxLengthWithMessage(50)
                .CanNotBeNullWithMessage()
                .CanNotBeEmptyWithMessage();
        }
    }
}
