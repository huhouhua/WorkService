using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkService.Domain.JobModule.JobTaskAggregate;

namespace WorkService.Infrastructure.JobModule.EntityConfigurations
{
    public class JobTaskEntityTypeConfiguration : IEntityTypeConfiguration<JobTask>
    {
        public void Configure(EntityTypeBuilder<JobTask> builder)
        {
            builder.HasKey(q => q.Id);
            builder.ToTable("Job_Task_t");
            builder.Property(q => q.JobIdentity).HasMaxLength(50);
            builder.Property(q => q.JobName).HasMaxLength(50);
            builder.Property(q => q.JobStatusTypeId);
            builder.Property(q => q.JobCronExpression).HasMaxLength(50);
            builder.Property(q => q.LastExecuteTime);
            builder.Property(q => q.HttpMethod).HasMaxLength(20);
            builder.Property(q => q.RequestUrl).HasMaxLength(200);
            builder.Property(q => q.RequestBody).HasMaxLength(500);
            builder.Property(q => q.RequestHeader).HasMaxLength(500);
            builder.Property(q => q.DeveloperPeople).HasMaxLength(20);
            builder.Property(q => q.AssignIp).HasMaxLength(20);
            builder.Property(q => q.Disabled);
            builder.Property(q => q.CreateTime);
            builder.Property(q => q.UpdateTime);
        }
    }

}
