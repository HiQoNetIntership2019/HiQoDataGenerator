using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Web.ViewModels
{
    public class FieldViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public FieldTypeViewModel FieldType { get; set; }
        public ICollection<ConstraintValueViewModel> Constraints { get; set; }
    }
}
