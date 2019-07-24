using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.UnitOfWork;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.DataSetModels;
using System;
using System.Collections.Generic;
using System.Text;
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


        public IEnumerable<DatasetTypeModel> GetAllTypes() =>
            _mapper.Map<IEnumerable<DatasetTypeModel>>(_datasetTypesRepository.GetAllAsync());

        public async Task<DatasetTypeModel> GetByIdAsync(int id) =>
            _mapper.Map<DatasetTypeModel>(await _datasetTypesRepository.GetByIdAsync(id));

        public async Task RemoveById(int id)
        {
            await _datasetTypesRepository.RemoveByIdAsync(id);
            await _uow.CommitAsync();
        }
    }
}
