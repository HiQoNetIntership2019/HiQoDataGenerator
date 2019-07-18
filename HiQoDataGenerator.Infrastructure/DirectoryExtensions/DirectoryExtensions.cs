using System.Diagnostics;
using System.IO;

namespace HiQoDataGenerator.Infrastructure.DirectoryExtensions
{
    public static class DirectoryExtensions
    {
        public static string GetCurrentDirectory()
        {
            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            return Path.GetDirectoryName(pathToExe);
        }
    }
}
