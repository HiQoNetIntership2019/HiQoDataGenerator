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
    public class DefinedDatasetService : IDefinedDatasetService
    {
        private readonly IDefinedDatasetRepository _definedDatasetRepository;
        private readonly IDatasetRepository _datasetRepository;
        private readonly IFieldTypeRepository _fieldTypeRepository;
        private readonly IUnitOfWork _uow;
        private IMapper _mapper;

        public DefinedDatasetService(IUnitOfWork unit, IDefinedDatasetRepository definedDatasetRepository, 
            IDatasetRepository datasetRepository, IFieldTypeRepository feFieldTypeRepository, IMapperFactory mapperFactory)
        {
            _uow = unit;
            _definedDatasetRepository = definedDatasetRepository;
            _datasetRepository = datasetRepository;
            _fieldTypeRepository = feFieldTypeRepository;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
        }
        
        public async Task AddAsync(DefinedDatasetModel definedDatasetModel)
        {
            var definedDataset = _mapper.Map<DefinedDataset>(definedDatasetModel);
            var dataset = _mapper.Map<Dataset>(definedDatasetModel);
            var definedDatasetValues = _mapper.Map<IEnumerable<DefinedDatasetValue>>(definedDatasetModel.Values).Select(item => { item.Dataset = definedDataset; return item; });
            
            await _definedDatasetRepository.AddAsync(definedDataset);
            await _definedDatasetRepository.AddValuesAsync(definedDatasetValues);
            await _datasetRepository.AddAsync(dataset);

            await _uow.CommitAsync();
        }
        
        public async Task AddValuesAsync(IEnumerable<DefinedDatasetValueModel> definedDatasetValueModels)
        {
            var definedDatasetValues = _mapper.Map<IEnumerable<DefinedDatasetValue>>(definedDatasetValueModels);
            await _definedDatasetRepository.AddValuesAsync(definedDatasetValues);
            await _uow.CommitAsync();
        }
        
        public async Task<IEnumerable<DefinedDatasetModel>> GetAllAsync()
        {
            var definedDatasets = await _definedDatasetRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DefinedDatasetModel>>(definedDatasets.ToList());
        }
        
        public async Task<DefinedDatasetModel> GetByIdAsync(int id)
        {
            var definedDataset = await _definedDatasetRepository.GetByIdAsync(id);
            if (definedDataset == null)
            {
                throw new InvalidDataException($"Can't get Defined Dataset with id {id}!");
            }
            return _mapper.Map<DefinedDatasetModel>(definedDataset);
        }

        public async Task<IEnumerable<DefinedDatasetModel>> GetDatasetsByTypeIdAsync(int id)
        {
            var type = await _fieldTypeRepository.GetByIdAsync(id);
            if (type == null)
            {
                throw new InvalidDataException($"Can't get Type with id {id}!");
            }
            var definedDatasets = type.Name.ToLower() != "enum" ? await _definedDatasetRepository.GetDatasetsByTypeIdAsync(id) : await _definedDatasetRepository.GetAllAsync();
            if (definedDatasets == null)
            {
                throw new InvalidDataException($"Can't get Defined Datasets with Type id {id} !");
            }
            return _mapper.Map<IEnumerable<DefinedDatasetModel>>(definedDatasets);
        }

        public async Task<IEnumerable<DefinedDatasetModel>> GetDatasetsByTypeNameAsync(string name)
        {
            var type = await _fieldTypeRepository.GetByNameAsync(name.ToLower());
            if (type == null)
            {
                throw new InvalidDataException($"Can't get Type <{name}>!");
            }
            var definedDatasets = type.Name.ToLower() != "enum" ? await _definedDatasetRepository.GetDatasetsByTypeNameAsync(name.ToLower()) : await _definedDatasetRepository.GetAllAsync();
            if (definedDatasets == null)
            {
                throw new InvalidDataException($"Can't get Defined Datasets with Type <{name}> !");
            }
            return _mapper.Map<IEnumerable<DefinedDatasetModel>>(definedDatasets);
        }
        
        public async Task<IEnumerable<DefinedDatasetValueModel>> GetValuesAsync()
        {
            var definedDatasetValues = await _definedDatasetRepository.GetValuesAsync();
            return _mapper.Map<IEnumerable<DefinedDatasetValueModel>>(definedDatasetValues);
        }
        
        public async Task<IEnumerable<DefinedDatasetValueModel>> GetValuesByDatasetIdAsync(int id)
        {
            var definedDatasetValues = await _definedDatasetRepository.GetValuesByDatasetIdAsync(id);
            if (definedDatasetValues == null)
            {
                throw new InvalidDataException($"Can't get values of Defined Dataset with id {id} !");
            }
            return _mapper.Map<IEnumerable<DefinedDatasetValueModel>>(definedDatasetValues);
        }

        public async Task<IEnumerable<DefinedDatasetValueModel>> GetValuesByDatasetNameAsync(string name)
        {
            var definedDatasetValues = await _definedDatasetRepository.GetValuesByDatasetNameAsync(name.ToLower());
            if (definedDatasetValues == null)
            {
                throw new InvalidDataException($"Can't get values of Defined Dataset <{name}> !");
            }
            return _mapper.Map<IEnumerable<DefinedDatasetValueModel>>(definedDatasetValues);
        }

        public async Task<DefinedDatasetModel> GetDatasetWithValuesByIdAsync(int id)
        {
            var definedDatasetValues = await _definedDatasetRepository.GetValuesByDatasetIdAsync(id);
            if (definedDatasetValues == null)
            {
                throw new InvalidDataException($"Can't get values of Defined Dataset with id {id} !");
            }
            var definedDatasetValueModels = _mapper.Map<IEnumerable<DefinedDatasetValueModel>>(definedDatasetValues);

            var definedDataset = await _definedDatasetRepository.GetByIdAsync(id);
            if (definedDataset == null)
            {
                throw new InvalidDataException($"Can't get Defined Dataset with id {id} !");
            }
            var definedDatasetModel = _mapper.Map<DefinedDatasetModel>(definedDataset);
            definedDatasetModel.Values = definedDatasetValueModels;
            return definedDatasetModel;
        }

        public async Task<bool> RemoveDatasetAsync(int datasetId)
        {
            var definedDataset = await _definedDatasetRepository.GetByIdAsync(datasetId);
            var result = await _definedDatasetRepository.RemoveByIdAsync(datasetId);

            var dataset = await _datasetRepository.GetByNameAsync(definedDataset.Name.ToLower());
            await _datasetRepository.RemoveByIdAsync(dataset.Id);
            await _uow.CommitAsync();
            return result;
        }
        
        public async Task<bool> RemoveValueByIdAsync(int valueId)
        {
            var result = await _definedDatasetRepository.RemoveValueByIdAsync(valueId);
            await _uow.CommitAsync();
            return result;
        }
    }
}
