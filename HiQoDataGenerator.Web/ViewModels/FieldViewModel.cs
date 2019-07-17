using System.Collections.Generic;

namespace HiQoDataGenerator.Web.ViewModels
{
    public class FieldViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public FieldTypeViewModel FieldType { get; set; }
        public ICollection<ConstraintValueViewModel> Constraints { get; set; }
        public int? DatasetId { get; set; }
    }
}
