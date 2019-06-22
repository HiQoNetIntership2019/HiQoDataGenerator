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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddLogging();
            services.AddScoped<LoggingAttribute>();

            services.AddBLServices();
            services.AddDALServices(Configuration.GetConnectionString("Connection"));

            services.AddMapperFactory();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.AddFile(_filenameForLog);
                app.UseDeveloperExceptionPage();
                app.InitializeMigrations();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionsHandlerMidlleware>();

            app.UseHttpsRedirection();
            app.UseMvc();
        }


    }
}
