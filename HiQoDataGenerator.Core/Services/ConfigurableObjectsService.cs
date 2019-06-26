using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.UnitOfWork;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Services
{
    public class ConfigurableObjectsService : IConfigurableObjectsService
    {
        private readonly IMapper _mapper;
        private readonly IConfigurableObjectsRepository _configurableObjectsRepository;
        private readonly IUnitOfWork _uow;

        public ConfigurableObjectsService(IUnitOfWork unit, IMapperFactory mapperFactory, IConfigurableObjectsRepository configurableObjectsRepository)
        {
            _uow = unit;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
            _configurableObjectsRepository = configurableObjectsRepository;
        }

        public async Task AddAsync(ConfigurableObjectModel configurableObject)
        {
            await _configurableObjectsRepository.AddAsync(_mapper.Map<ConfigurableObject>(configurableObject));
            await _uow.CommitAsync();
        }

        public IEnumerable<ConfigurableObjectModel> GetAll() =>
            _mapper.Map<IEnumerable<ConfigurableObjectModel>>(_configurableObjectsRepository.GetAll());

        public IEnumerable<ConfigurableObjectModel> GetByDateCreated(Predicate<DateTime> datePredicate) =>
            _mapper.Map<IEnumerable<ConfigurableObjectModel>>(_configurableObjectsRepository.GetByDateCreation(datePredicate));

        public async Task RemoveById(int id)
        {
            await _configurableObjectsRepository.RemoveByIdAsync(id);
            await _uow.CommitAsync();
        }
    }
}
