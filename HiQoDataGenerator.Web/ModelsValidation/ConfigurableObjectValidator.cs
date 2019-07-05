using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Infrastructure.ValidationExtensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class ConfigurableObjectValidator : AbstractValidator<ConfigurableObjectViewModel>
    {
        public ConfigurableObjectValidator()
        {
            RuleFor(x => x.Name)
                .MaxLengthWithMessage(50)
                .CanNotBeNullWithMessage()
                .CanNotBeEmptyWithMessage();

            RuleFor(x => x.Fields)
                .CanNotBeNullWithMessage();

            RuleForEach(x => x.Fields)
                .SetValidator(new FieldValidator());
        }
    }
}
