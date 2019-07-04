using FluentValidation;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.ViewModels.Helpers;
using HiQoDataGenerator.Infrastructure.ValidationExtensions;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class DefinedDatasetValidator : AbstractValidator<DefinedDatasetViewModel>
    {
        public DefinedDatasetValidator()
        {
            RuleFor(x => x.Name)
                .MaxLengthWithMessage(50)
                .CanNotBeNullWithMessage()
                .CanNotBeEmptyWithMessage();
        }
    }

    public class DefinedDatasetWithValuesValidator : AbstractValidator<AddDefinedDatasetWithValues>
    {
        public DefinedDatasetWithValuesValidator()
        {
            RuleFor(x => x.Name)
                .MaxLengthWithMessage(50)
                .CanNotBeNullWithMessage()
                .CanNotBeEmptyWithMessage();

            RuleForEach(x => x.Values)
                .SetValidator(new DefinedDatasetValueValidator());
        }
    }
}
