﻿using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.DAL;
using HiQoDataGenerator.Web.Attributes;
using HiQoDataGenerator.Web.Extensions;
using HiQoDataGenerator.Web.Middleware;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using ElmahCore.Mvc;
using HiQoDataGenerator.GeneratorCore;

namespace HiQoDataGenerator.Web
{
    public class Startup
    {
        private readonly string _filenameForLog = "Web.log";
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc(options => options.Filters.Add(new ModelStateFilter()))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddLogging();
            services.AddScoped<LoggingAttribute>();

            services.AddBLServices();
            services.AddGeneratorCoreSerives();
            services.AddDALServices(Configuration.GetConnectionString("PostgreConnection"));

            services.AddMapperFactory();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Data Generator API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddElmahService(Configuration.GetConnectionString("RedisConnection"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.AddFile(_filenameForLog);
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseElmah();
            app.UseMiddleware<ExceptionsHandlerMidlleware>();

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Data Generator API V1");
            });

            app.UseMvc();
        }
    }
}
