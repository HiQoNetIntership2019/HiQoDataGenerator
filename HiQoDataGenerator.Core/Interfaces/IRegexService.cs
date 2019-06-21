using System.Collections.Generic;
using System.Linq;
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IRegexService
    {
        IEnumerable<RegexModel> GetAll();
        IQueryable<string> GetAllNames();
        
    }
}
