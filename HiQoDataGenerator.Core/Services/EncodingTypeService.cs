using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Services
{
    public class EncodingTypeService: IEncodingTypesService
    {
        private readonly IEncodingTypeRepository _encodingTypeRepostory;
        private IMapper _mapper;

        public EncodingTypeService(IEncodingTypeRepository encodingTypeRepository, IMapperFactory mapperFactory)
        {
            _encodingTypeRepostory = encodingTypeRepository;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
        }

        public IEnumerable<EncodingTypeModel> GetAll()
        {
            var encodingTypes = _encodingTypeRepostory.GetAll();
            return _mapper.Map<IEnumerable<EncodingType>, IEnumerable<EncodingTypeModel>>(encodingTypes);
        }

        public async Task<EncodingTypeModel> GetByIdAsync(int id)
        {
            var encodingType = await _encodingTypeRepostory.GetByIdAsync(id);
            if (encodingType == null)
            {
                return null;
            }
            return _mapper.Map<EncodingTypeModel>(encodingType);
        }

        public async Task<bool> AddAsync(EncodingTypeModel encodingTypeModel)
        {
            var encodingType = _mapper.Map<EncodingType>(encodingTypeModel);
            return await _encodingTypeRepostory.AddAsync(encodingType);
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            return await _encodingTypeRepostory.RemoveByIdAsync(id);
        }

    }
}
