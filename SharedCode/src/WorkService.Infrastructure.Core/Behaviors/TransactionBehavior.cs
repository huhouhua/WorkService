using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WorkService.Infrastructure.Core.Extensions;

namespace WorkService.Infrastructure.Core.Behaviors
{
    /// <summary>
    /// 用来注入 事务的管理过程
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class TransactionBehavior<TDbContext, TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TDbContext : EFContext
    {
        private ILogger _logger;
        private TDbContext _dbContext;

        public TransactionBehavior(TDbContext dbContext, ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = default(TResponse);

            var typeName = request.GetGenericTypeName();

            try
            {
                //判断事务是否开启，开启就执行下一个动作
                if (_dbContext.HasActiveTransaction)
                {
                    return await next();
                }

                //开启数据库的操作执行的策略，可以嵌入一些重试的逻辑
                var strategy = _dbContext.Database.CreateExecutionStrategy();

                //执行策略
                await strategy.ExecuteAsync(async () =>
                {
                    Guid transactionId;

                    //开启事务
                    using (var transaction = await _dbContext.BeginTransactionAsync())

                    //记录事务的开启，如果异常会自动释放掉、会自动调用回滚。
                    using (_logger.BeginScope("TransactionContext:{TransactionId}", transaction.TransactionId))
                    {
                        _logger.LogInformation("----- 开始事务 {TransactionId} ({@Command})", transaction.TransactionId, typeName, request);

                        //执行后续的操作
                        response = await next();

                        _logger.LogInformation("----- 提交事务 {TransactionId} {CommandName}", transaction.TransactionId, typeName);

                        //事务的提交
                        await _dbContext.CommitTransactionAsync(transaction);

                        transactionId = transaction.TransactionId;
                    }
                });

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "处理事务出错 {CommandName} ({@Command})", typeName, request);

                throw;
            }


        }
    }
}
