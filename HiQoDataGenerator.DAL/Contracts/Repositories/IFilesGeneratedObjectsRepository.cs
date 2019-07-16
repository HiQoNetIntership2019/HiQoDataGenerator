using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IFilesGeneratedObjectsRepository
    {

        Task CreateAndWriteInFile(string value, string directoryName, string fileName);
        Task DeleteFile(string directoryName, string fileName);
        Task DeleteFile(string fullPath);
        Task<string> ReadFromFile(string directoryName, string fileName);
        Task<string> ReadFromFile(string fullPath);
    }
}
