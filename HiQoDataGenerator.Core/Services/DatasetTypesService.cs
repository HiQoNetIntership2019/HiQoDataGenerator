using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.UnitOfWork;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.DataSetModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Services
{
    public class DatasetTypesService : IDatasetTypesService
    {
        private readonly IMapper _mapper;
        private readonly IDatasetTypesRepository _datasetTypesRepository;
        private readonly IUnitOfWork _uow;

        public DatasetTypesService(IUnitOfWork unit, IMapperFactory mapperFactory, IDatasetTypesRepository datasetTypesRepository)
        {
            _uow = unit;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
            _datasetTypesRepository = datasetTypesRepository;
        }

        public async Task AddTypeAsync(DatasetTypeModel datasetTypeModel)
        {
            await _datasetTypesRepository.AddAsync(_mapper.Map<DatasetType>(datasetTypeModel));
            await _uow.CommitAsync();
        }


        public async Task<IEnumerable<DatasetTypeModel>> GetAllTypesAsync() =>
            _mapper.Map<IEnumerable<DatasetTypeModel>>(await _datasetTypesRepository.GetAllAsync());

        public async Task<DatasetTypeModel> GetByIdAsync(int id) =>
            _mapper.Map<DatasetTypeModel>(await _datasetTypesRepository.GetByIdAsync(id));

        public async Task<bool> RemoveByIdAsync(int id)
        {
            var result = await _datasetTypesRepository.RemoveByIdAsync(id);
            await _uow.CommitAsync();
            return result;
        }
    }
}
