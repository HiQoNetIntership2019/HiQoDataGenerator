using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    class TimezonesRepository : BaseRepository<Timezone>
    {
        public TimezonesRepository(DataContext context) : base(context) { }
    }
}
