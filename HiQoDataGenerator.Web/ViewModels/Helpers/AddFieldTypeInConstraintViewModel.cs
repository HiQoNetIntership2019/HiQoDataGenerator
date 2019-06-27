using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Web.ViewModels.Helpers
{
    public class AddFieldTypeInConstraintViewModel
    {
       public ConstraintViewModel ConstraintViewModel { get; set; }
       public IEnumerable<FieldTypeViewModel> FieldTypeViewModels { get; set; }
    }
}
