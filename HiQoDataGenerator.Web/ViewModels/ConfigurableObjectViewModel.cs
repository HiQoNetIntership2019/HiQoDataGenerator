using System;
using System.Collections.Generic;

namespace HiQoDataGenerator.Web.ViewModels
{
    public class ConfigurableObjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateChange { get; set; }
        public IEnumerable<FieldViewModel> Fields { get; set; }
        public ICollection<DefinedDatasetViewModel> Datasets { get; set; }
    }
}
