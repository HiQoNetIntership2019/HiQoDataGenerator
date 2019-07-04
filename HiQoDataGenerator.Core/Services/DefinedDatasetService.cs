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
        private readonly IUnitOfWork _uow;
        private IMapper _mapper;

        public DefinedDatasetService(IUnitOfWork unit, IDefinedDatasetRepository definedDatasetRepository, IMapperFactory mapperFactory)
        {
            _uow = unit;
            _definedDatasetRepository = definedDatasetRepository;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
        }

        public async Task AddAsync(DefinedDatasetModel definedDatasetModel)
        {
            var definedDataset = _mapper.Map<DefinedDataset>(definedDatasetModel);
            var definedDatasetValues = _mapper.Map<IEnumerable<DefinedDatasetValue>>(definedDatasetModel.Values).Select(item => { item.Dataset = definedDataset; return item; });
            await _definedDatasetRepository.AddAsync(definedDataset);
            await _definedDatasetRepository.AddValuesAsync(definedDatasetValues);

            await _uow.CommitAsync();
        }

        public async Task AddValuesAsync(IEnumerable<DefinedDatasetValueModel> definedDatasetValueModels)
        {
            var definedDatasetValues = _mapper.Map<IEnumerable<DefinedDatasetValue>>(definedDatasetValueModels);
            await _definedDatasetRepository.AddValuesAsync(definedDatasetValues);
            await _uow.CommitAsync();
        }

        public IEnumerable<DefinedDatasetModel> GetAll()
        {
            var definedDatasets = _definedDatasetRepository.GetAll().ToList();
            return _mapper.Map<IEnumerable<DefinedDatasetModel>>(definedDatasets);
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

        public IEnumerable<DefinedDatasetValueModel> GetValues()
        {
            var definedDatasetValues = _definedDatasetRepository.GetValues();
            return _mapper.Map<IEnumerable<DefinedDatasetValueModel>>(definedDatasetValues);
        }

        public IEnumerable<DefinedDatasetValueModel> GetValuesByDatasetId(int id)
        {
            var definedDatasetValues = _definedDatasetRepository.GetValuesByDatasetId(id);
            if (definedDatasetValues == null)
            {
                throw new InvalidDataException($"Can't get values of Defined Dataset with id {id} !");
            }
            return _mapper.Map<IEnumerable<DefinedDatasetValueModel>>(definedDatasetValues);
        }

        public IEnumerable<DefinedDatasetValueModel> GetValuesByDatasetName(string name)
        {
            var definedDatasetValues = _definedDatasetRepository.GetValuesByDatasetName(name.ToLower());
            if (definedDatasetValues == null)
            {
                throw new InvalidDataException($"Can't get values of Defined Dataset <{name}> !");
            }
            return _mapper.Map<IEnumerable<DefinedDatasetValueModel>>(definedDatasetValues);
        }

        public async Task RemoveDatasetAsync(int datasetId)
        {
            var result = await _definedDatasetRepository.RemoveByIdAsync(datasetId);
            if (!result)
            {
                throw new InvalidDataException($"Can't delete Defined Dataset with id {datasetId} !");
            }
            await _uow.CommitAsync();
        }

        public async Task RemoveValueByIdAsync(int valueId)
        {
            var result = await _definedDatasetRepository.RemoveValueByIdAsync(valueId);
            if (!result)
            {
                throw new InvalidDataException($"Can't delete Defined Dataset value with id {valueId} !");
            }
            await _uow.CommitAsync();
        }
    }
}
