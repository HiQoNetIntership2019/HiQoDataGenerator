using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Infrastructure.ValidationExtensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class RegexValidator : AbstractValidator<RegexViewModel>
    {
        public RegexValidator()
        {
            RuleFor(x => x.Name)
                .MaxLengthWithMessage(50)
                .CanNotBeNullWithMessage()
                .CanNotBeEmptyWithMessage();

            RuleFor(x => x.Value)
                .MaxLengthWithMessage(300)
                .CanNotBeNullWithMessage()
                .CanNotBeEmptyWithMessage();
        }
    }
}
