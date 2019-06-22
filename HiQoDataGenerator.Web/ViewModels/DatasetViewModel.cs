using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Web.ViewModels
{
    public class DatasetViewModel<T>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DatasetValueViewModel<T>> Values { get; set; }
    }
}
