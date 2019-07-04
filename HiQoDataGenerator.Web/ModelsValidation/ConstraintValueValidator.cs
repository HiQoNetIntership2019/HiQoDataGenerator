using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Infrastructure.ValidationExtensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class ConstraintValueValidator : AbstractValidator<ConstraintValueViewModel>
    {
        public ConstraintValueValidator()
        {
            RuleFor(x => x.Value)
                .MaxLengthWithMessage(300)
                .CanNotBeNullWithMessage()
                .CanNotBeEmptyWithMessage();


            RuleFor(x => x.ConstraintViewModel)
                .CanNotBeNullWithMessage()
                .SetValidator(new ConstraintValidator());
        }
    }
}
