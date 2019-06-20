using HiQoDataGenerator.DAL.Contracts.Repositories;
using Ninject;
using Ninject.Web.WebApi;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Web.Mvc;

namespace HiQoDataGenerator.Core.Infrastructure
{
    public class RepositoryManager
    {
        private readonly StandardKernel _kernel;
        public RepositoryManager()
        {
            var servicesInfrastructure = new ServicesInfrastructure();
            _kernel = new StandardKernel(servicesInfrastructure);
        }

        public ITimezoneRepository GetTimezoneRepository() => _kernel.Get<ITimezoneRepository>();
    }
}
