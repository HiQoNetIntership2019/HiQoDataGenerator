using System.Collections.Generic;

namespace HiQoDataGenerator.Web.ViewModels.Helpers
{
    public class AddDefinedDatasetWithValues
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public IEnumerable<DefinedDatasetValueViewModel> Values { get; set; }
    }
}
