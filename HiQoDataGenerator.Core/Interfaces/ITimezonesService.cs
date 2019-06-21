using HiQoDataGenerator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface ITimezonesService
    {
        IEnumerable<TimezoneModel> GetAll();
    }
}
