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
        private readonly IFieldTypeRepository _fieldTypeRepository;
        private readonly IUnitOfWork _uow;
        private IMapper _mapper;

        public DatasetService(IUnitOfWork unit, IDefinedDatasetRepository definedDatasetRepository, ICustomDatasetRepository customDatasetRepository,
            IDatasetRepository datasetRepository, IFieldTypeRepository fieldTypeRepository, IMapperFactory mapperFactory)
        {
            _uow = unit;
            _definedDatasetRepository = definedDatasetRepository;
            _customDatasetRepository = customDatasetRepository;
            _datasetRepository = datasetRepository;
            _fieldTypeRepository = fieldTypeRepository;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
        }

        public async Task<IEnumerable<DatasetModel>> GetAllAsync()
        {
            var datasets = await _datasetRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DatasetModel>>(datasets.ToList());
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
            var type = await _fieldTypeRepository.GetByIdAsync(id);
            if (type == null)
            {
                throw new InvalidDataException($"Can't get Type with id {id}!");
            }
            var datasets = type.Name.ToLower() != "enum" ? await _datasetRepository.GetDatasetsByTypeIdAsync(id) : await _datasetRepository.GetAllAsync();
            if (datasets == null)
            {
                throw new InvalidDataException($"Can't get Datasets with Type id {id}!");
            }
            return _mapper.Map<IEnumerable<DatasetModel>>(datasets);
        }
        
        public async Task<IEnumerable<DatasetModel>> GetDatasetsByTypeNameAsync(string name)
        {
            var type = await _fieldTypeRepository.GetByNameAsync(name.ToLower());
            if (type == null)
            {
                throw new InvalidDataException($"Can't get Type <{name}>!");
            }
            var datasets = type.Name.ToLower() != "enum" ? await _datasetRepository.GetDatasetsByTypeNameAsync(name) : await _datasetRepository.GetAllAsync();
            if (datasets == null)
            {
                throw new InvalidDataException($"Can't get Datasets with Type name <{name}>!");
            }
            return _mapper.Map<IEnumerable<DatasetModel>>(datasets);
        }

        private async Task<IEnumerable<DatasetValueModel>> GetValuesFromCustomDataset(string datasetName)
        {
            var customDataset = await _customDatasetRepository.GetDatasetByNameAsync(datasetName.ToLower());
            return _mapper.Map<IEnumerable<DatasetValueModel>>(await _customDatasetRepository.GetValuesByDatasetIdAsync(customDataset?.Id ?? 0));
        }

        private async Task<IEnumerable<DatasetValueModel>> GetValuesFromDefinedDataset(string datasetName)
        {
            var definedDataset = await _definedDatasetRepository.GetByNameAsync(datasetName.ToLower());
            return _mapper.Map<IEnumerable<DatasetValueModel>>(await _definedDatasetRepository.GetValuesByDatasetIdAsync(definedDataset?.Id ?? 0));
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
            var customDatasetValues = await _customDatasetRepository.GetValuesByDatasetIdAsync(customDataset?.Id ?? 0);
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
