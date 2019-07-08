using ElmahCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace HiQoDataGenerator.Web.Extensions
{
    public static class ElmahExtension
    {        
        public static void AddElmahService(this IServiceCollection services, string connectionString)
        {
            services.AddElmah(options => options.ConnectionString = connectionString);
        }
    }
}
