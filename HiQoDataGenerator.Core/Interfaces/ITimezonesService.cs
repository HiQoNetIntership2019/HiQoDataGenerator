using HiQoDataGenerator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface ITimezonesService
    {
        IEnumerable<TimezoneModel> GetAll();
        void Add(TimezoneModel model);
        Task<bool> RemoveById(int id);
        Task<TimezoneModel> GetById(int id); 
    }
}
