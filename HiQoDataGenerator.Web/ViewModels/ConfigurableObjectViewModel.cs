using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Web.ViewModels
{
    public class ConfigurableObjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateChange { get; set; }

    }
}
