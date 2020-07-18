using System;
using System.Collections.Generic;
using System.Text;
using DotNetCore.CAP;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkService.Infrastructure.Core;
using WorkService.Infrastructure.JobModule.EntityConfigurations;

namespace WorkService.Infrastructure
{
    public class WorkServiceContext:EFContext
    {
        public WorkServiceContext(DbContextOptions options,IMediator mediator,ICapPublisher capBus):base(options,mediator,capBus) 
        {
        
        
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new JobTaskEntityTypeConfiguration());


            base.OnModelCreating(modelBuilder);
        }

    }
}
