using System;
using System.Collections.Generic;
using System.Text;
using WorkService.Domain.Abstractions;

namespace WorkService.Domain.JobModule.JobTaskAggregate
{
    public class JobTask : Entity<string>, IAggregateRoot
    {
        public JobTask() 
        {
        
        }

        public string JobIdentity { get; set; }

        public string JobName { get; set; }

        public int JobStatusTypeId { get; set; }

        public string JobCronExpression { get; set; }

        public DateTime LastExecuteTime { get; set; }

        public string HttpMethod { get; set; }

        public string RequestUrl { get; set; }

        public string RequestBody { get; set; }

        public string RequestHeader { get; set; }

        public string DeveloperPeople { get; set; }

        public string AssignIp { get; set; }

        public bool Disabled { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }
      

    }
}
