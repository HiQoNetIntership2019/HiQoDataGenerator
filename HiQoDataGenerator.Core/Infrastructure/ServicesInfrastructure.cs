using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Repositories.EntityFramework;
using AutoMapper;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Core.Infrastructure
{
    public class ServicesInfrastructure : NinjectModule
    {
        public override void Load()
        {
            Bind<ITimezoneRepository>().To<TimezonesRepository>();
            
        }
    }
}
