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
    public class DatasetService : IDatasetService
    {
        private readonly IDefinedDatasetRepository _definedDatasetRepository;
        private readonly ICustomDatasetRepository _customDatasetRepository;
        private readonly IDatasetRepository _datasetRepository;
        private readonly IUnitOfWork _uow;
        private IMapper _mapper;

        public DatasetService(IUnitOfWork unit, IDefinedDatasetRepository definedDatasetRepository, 
            ICustomDatasetRepository customDatasetRepository, IDatasetRepository datasetRepository, IMapperFactory mapperFactory)
        {
            _uow = unit;
            _definedDatasetRepository = definedDatasetRepository;
            _customDatasetRepository = customDatasetRepository;
            _datasetRepository = datasetRepository;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
        }

        public IEnumerable<DatasetModel> GetAll()
        {
            var datasets = _datasetRepository.GetAll().ToList();
            return _mapper.Map<IEnumerable<DatasetModel>>(datasets);
        }

        public async Task<DatasetModel> GetByIdAsync(int id)
        {
            var dataset = await _datasetRepository.GetByIdAsync(id);
            if (dataset == null)
            {
                throw new InvalidDataException($"Can't get Dataset with id {id}!");
            }
            return _mapper.Map<DatasetModel>(dataset);
        }

        public async Task<DatasetModel> GetByNameAsync(string name)
        {
            var dataset = await _datasetRepository.GetByNameAsync(name.ToLower());
            if (dataset == null)
            {
                throw new InvalidDataException($"Can't get Dataset with name {name}!");
            }
            return _mapper.Map<DatasetModel>(dataset);
        }

        public async Task<IEnumerable<DatasetModel>> GetDatasetsByTypeIdAsync(int id)
        {
            var datasets = await _datasetRepository.GetDatasetsByTypeIdAsync(id);
            if (datasets == null)
            {
                throw new InvalidDataException($"Can't get Datasets with Type id {id}!");
            }
            return _mapper.Map<IEnumerable<DatasetModel>>(datasets);
        }
        
        public async Task<IEnumerable<DatasetModel>> GetDatasetsByTypeNameAsync(string name)
        {
            var datasets = await _datasetRepository.GetDatasetsByTypeNameAsync(name);
            if (datasets == null)
            {
                throw new InvalidDataException($"Can't get Datasets with Type name <{name}>!");
            }
            return _mapper.Map<IEnumerable<DatasetModel>>(datasets);
        }

        private async Task<IEnumerable<DatasetValueModel>> GetValuesFromCustomDataset(string datasetName)
        {
            var customDataset = await _customDatasetRepository.GetDatasetByNameAsync(datasetName.ToLower());
            return _mapper.Map<IEnumerable<DatasetValueModel>>(_customDatasetRepository.GetValuesByDatasetId(customDataset == null ? 0 : customDataset.Id));
        }

        private async Task<IEnumerable<DatasetValueModel>> GetValuesFromDefinedDataset(string datasetName)
        {
            var definedDataset = await _definedDatasetRepository.GetByNameAsync(datasetName.ToLower());
            return _mapper.Map<IEnumerable<DatasetValueModel>>(_definedDatasetRepository.GetValuesByDatasetId(definedDataset == null ? 0 : definedDataset.Id));
        }

        public async Task<IEnumerable<DatasetValueModel>> GetValuesByDatasetIdAsync(int id)
        {
            var dataset = await _datasetRepository.GetByIdAsync(id);
            if (dataset == null)
            {
                throw new InvalidDataException($"Can't get Dataset with id {id}!");
            }
            if (dataset.IsDefined)
            {
                return await GetValuesFromDefinedDataset(dataset.Name);
            }
            else
            {
                return await GetValuesFromCustomDataset(dataset.Name);
            }
        }

        public async Task<IEnumerable<DatasetValueModel>> GetValuesByDatasetNameAsync(string name)
        {
            var dataset = await _datasetRepository.GetByNameAsync(name.ToLower());
            if (dataset == null)
            {
                throw new InvalidDataException($"Can't get Dataset <{name}>!");
            }
            if (dataset.IsDefined)
            {
                return await GetValuesFromDefinedDataset(dataset.Name);
            }
            else
            {
                return await GetValuesFromCustomDataset(dataset.Name);
            }
        }

        public async Task ToDefinedDatasetAsync(int datasetId)
        {
            var dataset = await GetByIdAsync(datasetId);
            if (dataset.IsDefined)
                throw new InvalidDataException($"Dataset <{dataset.Name}> is already defined!");
            
            var customDataset = await _customDatasetRepository.GetDatasetByNameAsync(dataset.Name.ToLower());
            var customDatasetValues = _customDatasetRepository.GetValuesByDatasetId(customDataset == null ? 0 : customDataset.Id);
            await _customDatasetRepository.RemoveByIdAsync(customDataset.Id);

            var definedDataset = _mapper.Map<DefinedDataset>(dataset);
            await _datasetRepository.ToDefinedDatasetAsync(dataset.Id);
            await _definedDatasetRepository.AddAsync(definedDataset);
            await _definedDatasetRepository.AddValuesAsync(_mapper.Map<IEnumerable<DefinedDatasetValue>>(customDatasetValues)
                .Select(item => { item.Dataset = definedDataset; return item; }));

            await _uow.CommitAsync();
        }
    }
}
