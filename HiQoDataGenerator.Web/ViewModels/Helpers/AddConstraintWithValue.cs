using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Web.ViewModels.Helpers
{
    public class AddConstraintWithValue
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public ConstraintViewModel Constraint { get; set; }
    }
}
