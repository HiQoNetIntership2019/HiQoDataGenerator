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

        public EncodingTypeService(IEncodingTypeRepository encodingTypeRepository)
        {
            _encodingTypeRepostory = encodingTypeRepository;
        }

        public IEnumerable<EncodingTypeModel> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EncodingType, EncodingTypeModel>()).CreateMapper();
            return mapper.Map<IEnumerable<EncodingType>, IEnumerable<EncodingTypeModel>>(_encodingTypeRepostory.GetAll());
        }

        public async Task<EncodingTypeModel> GetByIdAsync(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EncodingType, EncodingTypeModel>()).CreateMapper();
            return mapper.Map<EncodingType, EncodingTypeModel>(await _encodingTypeRepostory.GetById(id));
        }

    }
}
