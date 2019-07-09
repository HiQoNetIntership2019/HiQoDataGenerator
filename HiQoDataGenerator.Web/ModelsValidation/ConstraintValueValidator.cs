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
                .CanNotBeNullWithMessage()
                .CanNotBeEmptyWithMessage();


            RuleFor(x => x.ConstraintType)
                .CanNotBeNullWithMessage()
                .SetValidator(new ConstraintValidator());
        }
    }
}
