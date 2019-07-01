using FluentValidation;
using HiQoDataGenerator.DAL.Models.DataSetModels;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class DatasetTypeValidator : AbstractValidator<DatasetType>
    {
        public DatasetTypeValidator()
        {
            RuleFor(x => x.TypeName)
                .MaximumLength(50)
                .NotNull()
                .NotEmpty();
        }
    }
}
