using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.GeneratedObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Services
{
    public class GeneratedObjectsService : IGeneratedObjectsService
    {
        private readonly IMapper _mapper;
        private readonly IGeneratedObjectsRepository _generatedObjectsRepository;

        public GeneratedObjectsService(IMapperFactory factory, IGeneratedObjectsRepository generatedObjectsRepository)
        {
            _mapper = factory.GetMapper(typeof(CoreServices).Name);
            _generatedObjectsRepository = generatedObjectsRepository;
        }

        public IEnumerable<GeneratedObjectModel> GetAll()
        {
            return _mapper.Map<IEnumerable<GeneratedObjectModel>>(_generatedObjectsRepository.GetAll());
        }

        public async Task Add(GeneratedObjectModel generatedObject)
        {
            await _generatedObjectsRepository.AddAsync(_mapper.Map<CustomGeneratedObject>(generatedObject));
        }

        public async Task RemoveById(string id)
        {
            await _generatedObjectsRepository.RemoveByIdAsync(id);
        }

        public async Task AddRange(IEnumerable<GeneratedObjectModel> generatedObjects)
        {
            await _generatedObjectsRepository.AddRangeAsync(_mapper.Map<IEnumerable<CustomGeneratedObject>>(generatedObjects));
        }
    }
}
