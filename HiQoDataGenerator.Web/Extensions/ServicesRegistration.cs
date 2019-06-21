﻿using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HiQoDataGenerator.Web.Extensions
{
    public static class ServicesRegistration
    {
        public static void AddTimezoneRepository(this IServiceCollection services)
            => services.AddScoped<ITimezonesService, TimezoneService>();
    }
}