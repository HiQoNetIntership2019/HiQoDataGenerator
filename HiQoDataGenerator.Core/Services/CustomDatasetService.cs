using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.DataSetModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.UnitOfWork;
using System.Linq;

namespace HiQoDataGenerator.Core.Services
{
    public class CustomDatasetService : ICustomDatasetService
    {
        private readonly ICustomDatasetRepository _customDatasetRepository;
        private readonly IUnitOfWork _uow;
        private IMapper _mapper;

        public CustomDatasetService(IUnitOfWork unit, ICustomDatasetRepository customDatasetRepository, IMapperFactory mapperFactory)
        {
            _uow = unit;
            _customDatasetRepository = customDatasetRepository;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
        }

        public IEnumerable<CustomDatasetModel> GetAll()
        {
            var customDatasets = _customDatasetRepository.GetAll().ToList();
            return _mapper.Map<IEnumerable<CustomDatasetModel>>(customDatasets);
        }

        public IEnumerable<CustomDatasetValueModel> GetValues()
        {
            var customDatasetValues = _customDatasetRepository.GetValues().ToList();
            return _mapper.Map<IEnumerable<CustomDatasetValueModel>>(customDatasetValues);
        }

        public async Task<CustomDatasetModel> GetByIdAsync(int id)
        {
            var customDataset = await _customDatasetRepository.GetByIdAsync(id);
            if (customDataset == null)
            {
                throw new InvalidDataException($"Can't get Custom Dataset with id {id}!");
            }
            return _mapper.Map<CustomDatasetModel>(customDataset);
        }

        public IEnumerable<CustomDatasetValueModel> GetValuesByDatasetId(int id)
        {
            var customDatasetValues = _customDatasetRepository.GetValuesByDatasetId(id)?.ToList();
            if (customDatasetValues == null)
            {
                throw new InvalidDataException($"Can't get values of Custom Dataset with id {id} !");
            }
            return _mapper.Map<IEnumerable<CustomDatasetValueModel>>(customDatasetValues);
        }

        public IEnumerable<CustomDatasetValueModel> GetValuesByDatasetName(string name)
        {
            var customDatasetValues = _customDatasetRepository.GetValuesByDatasetName(name.ToLower())?.ToList();
            if (customDatasetValues == null)
            {
                throw new InvalidDataException($"Can't get values of Custom Dataset <{name}> !");
            }
            return _mapper.Map<IEnumerable<CustomDatasetValueModel>>(customDatasetValues);
        }

        public async Task AddValuesAsync(IEnumerable<CustomDatasetValueModel> customDatasetValueModels)
        {
            var customDatasetValues = _mapper.Map<IEnumerable<CustomDatasetValue>>(customDatasetValueModels);
            await _customDatasetRepository.AddValuesAsync(customDatasetValues);
            await _uow.CommitAsync();
        }
        
        public async Task AddAsync(CustomDatasetModel customDatasetModel)
        {
            var customDataset = _mapper.Map<CustomDataset>(customDatasetModel);
            var customDatasetValues = _mapper.Map<IEnumerable<CustomDatasetValue>>(customDatasetModel.Values).Select(item => { item.Dataset = customDataset; return item;}).ToList();
            await _customDatasetRepository.AddAsync(customDataset);
            await _customDatasetRepository.AddValuesAsync(customDatasetValues);

            await _uow.CommitAsync();
        }

        public async Task RemoveDatasetAsync(int datasetId)
        {
            var result = await _customDatasetRepository.RemoveByIdAsync(datasetId);
            if (!result)
            {
                throw new InvalidDataException($"Can't delete Custom Dataset with id {datasetId} !");
            }
            await _uow.CommitAsync();
        }

        public async Task RemoveValueByIdAsync(int valueId)
        {
            var result = await _customDatasetRepository.RemoveValueByIdAsync(valueId);
            if (!result)
            {
                throw new InvalidDataException($"Can't delete Custom Dataset value with id {valueId} !");
            }
            await _uow.CommitAsync();
        }
    }
}
