using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.Extensions;
using HiQoDataGenerator.Infrastructure.ValidationExtensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class FieldValidator : AbstractValidator<FieldViewModel>
    {
        public FieldValidator()
        {
            RuleFor(x => x.Name)
                .MaxLengthWithMessage(150)
                .CanNotBeNullWithMessage()
                .CanNotBeEmptyWithMessage();

            RuleFor(x => x.IsRequired)
                .CanNotBeNullWithMessage();

            RuleFor(x => x.Constraints)
                .CanNotBeNullWithMessage();

            RuleForEach(x => x.Constraints)
                .SetValidator(new ConstraintValueValidator());

            RuleFor(x => x.FieldType)
                .CanNotBeNullWithMessage()
                .SetValidator(new FieldTypeValidator());
        }
    }
}
