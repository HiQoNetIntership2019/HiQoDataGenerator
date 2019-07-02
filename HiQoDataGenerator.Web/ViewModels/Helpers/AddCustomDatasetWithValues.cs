using System.Collections.Generic;

namespace HiQoDataGenerator.Web.ViewModels.Helpers
{
    public class AddCustomDatasetWithValues
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CustomDatasetValueViewModel> Values {get; set;}
    }
}
