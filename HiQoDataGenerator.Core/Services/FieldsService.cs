using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.UnitOfWork;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Services
{ 
    public class FieldsService : IFieldsService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFieldRepository _fieldRepository;

        public FieldsService(IMapperFactory mapperFactory, IUnitOfWork unitOfWork, IFieldRepository fieldRepository)
        {
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
            _unitOfWork = unitOfWork;
            _fieldRepository = fieldRepository;
        }

        public async Task<IEnumerable<FieldModel>> GetAllAsync() =>
            _mapper.Map<IEnumerable<FieldModel>>(await _fieldRepository.GetAllWithTypesAsync());

        public async Task AddAsync(FieldModel model)
        {
            await _fieldRepository.AddAsync(_mapper.Map<Field>(model));
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            bool isRemoved = await _fieldRepository.RemoveByIdAsync(id);
            await _unitOfWork.CommitAsync();
            return isRemoved;
        }

        public async Task<FieldModel> GetByIdAsync(int id) =>
            _mapper.Map<FieldModel>(await _fieldRepository.GetByIdAsync(id));
        
    }
}
