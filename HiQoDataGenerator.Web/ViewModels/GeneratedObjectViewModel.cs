using System.Collections.Generic;

namespace HiQoDataGenerator.Web.ModelsValidation
{
    public class GeneratedObjectViewModel
    {
        public string Name { get; set; }
        public IEnumerable<GeneratedFieldViewModel> Fields { get; set; }
    }
}
