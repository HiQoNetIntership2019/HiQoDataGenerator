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
            var customDatasets = _customDatasetRepository.GetAll();
            return _mapper.Map<IEnumerable<CustomDatasetModel>>(customDatasets);
        }

        public IEnumerable<CustomDatasetValueModel> GetAllValues()
        {
            var customDatasetValues = _customDatasetRepository.GetAllValues().ToList();
            return _mapper.Map<IEnumerable<CustomDatasetValueModel>>(customDatasetValues);
        }

        public async Task<CustomDatasetModel> GetByIdAsync(int id)
        {
            var customDataset = await _customDatasetRepository.GetByIdAsync(id);
            if (customDataset == null)
            {
                throw new InvalidDataException("Can't get Custom Dataset with id " + id.ToString() + " !");
            }
            return _mapper.Map<CustomDatasetModel>(customDataset);
        }

        public async Task AddAsync(CustomDatasetModel customDatasetModel)
        {
            var customDataset = _mapper.Map<CustomDataset>(customDatasetModel);
            await _customDatasetRepository.AddAsync(customDataset);
            await _uow.CommitAsync();
        }

        public async Task AddRangeAsync(IEnumerable<CustomDatasetModel> customDatasetsModels)
        {
            var customDatasets = _mapper.Map<IEnumerable<CustomDataset>>(customDatasetsModels);
            await _customDatasetRepository.AddRangeAsync(customDatasets);
            await _uow.CommitAsync();
        }

        public async Task RemoveByIdAsync(int id)
        {
            var result = await _customDatasetRepository.RemoveByIdAsync(id);
            if (!result)
            {
                throw new InvalidDataException("Can't delete Custom Dataset with id " + id.ToString() + " !");
            }
            await _uow.CommitAsync();
        }
    }
}
