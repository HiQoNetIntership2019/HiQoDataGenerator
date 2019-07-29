using HiQoDataGenerator.DAL.Models.DataSetModels;
using Microsoft.EntityFrameworkCore;

namespace HiQoDataGenerator.DAL.Extensions
{
    public static class StateSeeds
    {
        public static void SeedStates(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DefinedDatasetValue>()
                .HasData(
                    new DefinedDatasetValue { Id = 1, Value = "Alabama", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 3, Value = "Arizona", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 4, Value = "Arkansas", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 5, Value = "California", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 6, Value = "Colorado", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 7, Value = "Connecticut", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 8, Value = "Delaware", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 9, Value = "District of Columbia", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 10, Value = "Florida", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 11, Value = "Georgia", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 12, Value = "Hawaii", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 13, Value = "Idaho", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 14, Value = "Illinois", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 15, Value = "Indiana", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 16, Value = "Iowa", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 17, Value = "Kansas", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 18, Value = "Kentucky", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 19, Value = "Louisiana", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 20, Value = "Maine", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 21, Value = "Montana", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 22, Value = "Nebraska", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 23, Value = "Nevada", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 24, Value = "New Hampshire", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 25, Value = "New Jersey", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 26, Value = "New Mexico", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 27, Value = "New York", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 28, Value = "North Carolina", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 29, Value = "North Dakota", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 30, Value = "Ohio", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 31, Value = "Oklahoma", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 32, Value = "Oregon", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 33, Value = "Maryland", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 34, Value = "Massachusetts", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 35, Value = "Michigan", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 36, Value = "Minnesota", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 37, Value = "Mississippi", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 38, Value = "Missouri", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 39, Value = "Pennsylvania", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 40, Value = "Rhode Island", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 41, Value = "South Carolina", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 42, Value = "South Dakota", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 43, Value = "Tennessee", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 44, Value = "Texas", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 45, Value = "Utah", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 46, Value = "Vermont", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 47, Value = "Virginia", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 48, Value = "Washington", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 49, Value = "West Virginia", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 50, Value = "Wisconsin", DatasetId = 1, },
                    new DefinedDatasetValue { Id = 51, Value = "Wyoming", DatasetId = 1, }
                );
        }
    }
}
