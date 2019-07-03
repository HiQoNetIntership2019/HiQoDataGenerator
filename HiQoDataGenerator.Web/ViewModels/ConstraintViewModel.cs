using System.Collections.Generic;

namespace HiQoDataGenerator.Web.ViewModels
{
    public class ConstraintViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<FieldTypeViewModel> FieldTypes { get; set; }
    }
}
