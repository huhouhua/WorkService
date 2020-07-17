using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkService.Infrastructure.Core
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 保存   返回受影响的行数
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);


        /// <summary>
        /// 保存  返回是否成功
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
