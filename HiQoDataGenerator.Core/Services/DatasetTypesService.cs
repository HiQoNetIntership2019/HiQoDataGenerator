using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
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
        public DatasetTypesService(IMapperFactory mapperFactory, IDatasetTypesRepository datasetTypesRepository)
        {
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
            _datasetTypesRepository = datasetTypesRepository;
        }

        public async Task AddTypeAsync(DatasetTypeModel datasetTypeModel) => 
            await _datasetTypesRepository.AddAsync(_mapper.Map<DatasetType>(datasetTypeModel));


        public IEnumerable<DatasetTypeModel> GetAllTypes() => 
            _mapper.Map<IEnumerable<DatasetTypeModel>>(_datasetTypesRepository.GetAll());

        public async Task<DatasetTypeModel> GetByIdAsync(int id) =>
            _mapper.Map<DatasetTypeModel>(await _datasetTypesRepository.GetByIdAsync(id));

        public async Task RemoveById(int id) => await _datasetTypesRepository.RemoveByIdAsync(id);
    }
}
