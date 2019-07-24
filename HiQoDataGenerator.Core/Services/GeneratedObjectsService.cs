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

        public async Task<IEnumerable<GeneratedObjectModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<GeneratedObjectModel>>(await _generatedObjectsRepository.GetAllAsync());
        }

        public async Task AddAsync(GeneratedObjectModel generatedObject)
        {
            await _generatedObjectsRepository.AddAsync(_mapper.Map<CustomGeneratedObject>(generatedObject));
        }

        public async Task RemoveByIdAsync(string id)
        {
            await _generatedObjectsRepository.RemoveByIdAsync(id);
        }

        public async Task AddRangeAsync(IEnumerable<GeneratedObjectModel> generatedObjects)
        {
            await _generatedObjectsRepository.AddRangeAsync(_mapper.Map<IEnumerable<CustomGeneratedObject>>(generatedObjects));
        }
    }
}
