using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IRegexService
    {
        IEnumerable<RegexModel> GetAll();
        IQueryable<string> GetAllNames();
        
    }
}
