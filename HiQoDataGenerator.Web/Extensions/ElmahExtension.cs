using System.Collections.Generic;
using ElmahCore;
using ElmahCore.Mvc;
using HiQoDataGenerator.Web.LoggingInfrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace HiQoDataGenerator.Web.Extensions
{
    public static class ElmahExtension
    {        
        public static void AddElmahService(this IServiceCollection services, string connectionString)
        {
            services.AddElmah<RedisErrorLog>(options =>
            {
                options.ConnectionString = connectionString;
            });
        }
    }
}
