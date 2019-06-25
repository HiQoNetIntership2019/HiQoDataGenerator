using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Exceptions;

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
                throw new InvalidDataException("Can't get Encoding Type with id " + id.ToString() + " !");
            }
            return _mapper.Map<EncodingTypeModel>(encodingType);
        }

        public async Task AddAsync(EncodingTypeModel encodingTypeModel)
        {
            var encodingType = _mapper.Map<EncodingType>(encodingTypeModel);
            await _encodingTypeRepostory.AddAsync(encodingType);
        }

        public async Task RemoveByIdAsync(int id)
        {
            var result = await _encodingTypeRepostory.RemoveByIdAsync(id);
            if (!result)
            {
                throw new InvalidDataException("Can't delete Encoding Type with id " + id.ToString() + " !");
            }
        }

    }
}
