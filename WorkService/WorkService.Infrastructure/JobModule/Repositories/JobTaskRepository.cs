using System;
using System.Collections.Generic;
using System.Text;
using WorkService.Domain.JobModule.JobTaskAggregate;
using WorkService.Infrastructure.Core;

namespace WorkService.Infrastructure.JobModule.Repositories
{
    public class JobTaskRepository : Repository<JobTask, string, WorkServiceContext>, IJobTaskRepository
    {
        public JobTaskRepository(WorkServiceContext context) : base(context)
        {


        }
    }
}
