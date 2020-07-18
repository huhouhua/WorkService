using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using WorkService.Infrastructure.Core.Behaviors;

namespace WorkService.Infrastructure
{
    /// <summary>
    ///  事务的管理过程
    /// </summary>
    public class WorkServiceContextTransactionBehavior<TRequest, TResponse> : TransactionBehavior<WorkServiceContext, TRequest, TResponse>
    {
        public WorkServiceContextTransactionBehavior(WorkServiceContext dbContext, ILogger<WorkServiceContextTransactionBehavior<TRequest, TResponse>> logger) : base(dbContext, logger)
        {

        }
    }
}
