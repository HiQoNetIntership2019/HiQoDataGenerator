using AutoMapper;
using HiQoDataGenerator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Extensions
{
    public class MapperFactory : IMapperFactory
    {
        public Dictionary<string, IMapper> Mappers { get; set; } = new Dictionary<string, IMapper>();
        public IMapper GetMapper(string factoryName = "") => Mappers[factoryName];
    }
}
