using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Web.ViewModels
{
    public class ConstraintValueViewModel
    {
        public int Id { get; set; }
        public dynamic Value { get; set; }
        public ConstraintViewModel ConstraintType { get; set; }
    }
}
