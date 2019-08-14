using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.UnitOfWork;

namespace HiQoDataGenerator.Core.Services
{
    public class EncodingTypeService: IEncodingTypesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IEncodingTypeRepository _repo;
        private IMapper _mapper;

        public EncodingTypeService(IUnitOfWork unit, IEncodingTypeRepository repo, IMapperFactory mapperFactory)
        {
            _uow = unit;
            _repo = repo;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
        }

        public async Task<IEnumerable<EncodingTypeModel>> GetAllAsync()
        {
            var encodingTypes = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<EncodingType>, IEnumerable<EncodingTypeModel>>(encodingTypes);
        }

        public async Task<EncodingTypeModel> GetByIdAsync(int id)
        {
            var encodingType = await _repo.GetByIdAsync(id);
            if (encodingType == null)
            {
                throw new InvalidDataException($"Can't get Encoding Type with id {id}!");
            }
            return _mapper.Map<EncodingTypeModel>(encodingType);
        }

        public async Task AddAsync(EncodingTypeModel encodingTypeModel)
        {
            var encodingType = _mapper.Map<EncodingType>(encodingTypeModel);
            await _repo.AddAsync(encodingType);
            await _uow.CommitAsync();
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            var result = await _repo.RemoveByIdAsync(id);
            await _uow.CommitAsync();
            return result;
        }
    }
}
