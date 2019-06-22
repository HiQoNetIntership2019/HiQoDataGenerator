using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Entities.Datasets;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Extensions;
using HiQoDataGenerator.DAL.Contracts.Repositories.Datasets;
using System;
using HiQoDataGenerator.DAL.Models.DataSetModels;
using System.Collections.Generic;

namespace HiQoDataGenerator.Core.Services
{
    public enum DefinedDatasetsNames
    {
        // Add new defined DatasetRepositories here
        Countries
    }

    public class DefinedDatasetsService : IDefinedDatasetsService
    {
        private readonly ICountriesDatasetRepository _countriesDatasetRepository;
        private readonly IMapper _mapper;
        public DefinedDatasetsService(IMapperFactory mapperFactory, ICountriesDatasetRepository countriesDatasetRepository)
        {
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
            // Add new defined DatasetRepositories here
            _countriesDatasetRepository = countriesDatasetRepository;
        }
        public DatasetModel<string> GetSetOfStringByName(string name)
        {
            name = name.ToLowerAndFirstToUpper();

            if (name == Enum.GetName(typeof(DefinedDatasetsNames), DefinedDatasetsNames.Countries))
            {
                var countries = _mapper.Map<IEnumerable<DatasetValueModel<string>>>(_countriesDatasetRepository.GetAll());
                return new DatasetModel<string>(0, name, countries);
            }
            throw new DatasetNotFoundException(name);
        }

        public async void AddValueIn<T>(string datasetName, DatasetValueModel<T> value)
        {
            datasetName = datasetName.ToLowerAndFirstToUpper();
            if (datasetName == Enum.GetName(typeof(DefinedDatasetsNames), DefinedDatasetsNames.Countries))
            {
                await _countriesDatasetRepository.AddAsync(_mapper.Map<CountryDataset>(value));
            }
        }
    }
}
