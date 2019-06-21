using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IMapperFactory
    {
        IMapper GetMapper(string factoryName);
    }
}
