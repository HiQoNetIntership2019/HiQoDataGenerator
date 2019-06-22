using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Web.ViewModels.Dataset
{
    public class DatasetViewModel<T>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<(int id, T value)> Values { get; set; }
    }
}
