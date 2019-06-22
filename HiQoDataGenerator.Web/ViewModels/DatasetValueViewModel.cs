using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Web.ViewModels
{
    public class DatasetValueViewModel<T>
    {
        public int Id { get; set; }
        public T Value { get; set; }
    }
}
