using System;
using System.Collections.Generic;
using System.Text;
using WorkService.Domain.JobModule.JobTaskAggregate;
using WorkService.Infrastructure.Core;

namespace WorkService.Infrastructure.JobModule.Repositories
{
    public interface IJobTaskRepository : IRepository<JobTask, string>
    {
        
    }
}
