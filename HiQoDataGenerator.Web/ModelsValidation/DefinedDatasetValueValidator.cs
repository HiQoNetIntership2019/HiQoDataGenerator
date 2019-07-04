using HiQoDataGenerator.Web.ViewModels.Helpers;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Infrastructure.ValidationExtensions;
using FluentValidation;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class DefinedDatasetValuesValidator : AbstractValidator<AddDefinedDatasetValues>
    {
        public DefinedDatasetValuesValidator()
        {
            RuleForEach(x => x.Values)
              .SetValidator(new DefinedDatasetValueValidator());
        }
    }

    public class DefinedDatasetValueValidator : AbstractValidator<DefinedDatasetValueViewModel>
    {
        public DefinedDatasetValueValidator()
        {
            RuleFor(x => x.Value)
               .MaxLengthWithMessage(150)
               .CanNotBeNullWithMessage()
               .CanNotBeEmptyWithMessage();
        }
    }
}
