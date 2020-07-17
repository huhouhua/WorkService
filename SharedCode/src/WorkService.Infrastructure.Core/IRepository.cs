using WorkService.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkService.Infrastructure.Core
{

    /// <summary>
    /// 普通的仓储
    /// 描述：TEntity:约束必须继承Entity、和实现IAggregateRoot接口,也就是说仓储里面存储的对象必须是聚合根对象
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    public interface IRepository<TEntity> where TEntity : Entity, IAggregateRoot
    {
        /// <summary>
        /// 工作单元
        /// </summary>
        IUnitOfWork UnitOfWork { get; }


        TEntity Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity,CancellationToken cancellationToken =default);


        TEntity Update(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity,CancellationToken cancellationToken = default);

        bool Remove(Entity entity);

        Task<bool> RemoveAsync(Entity entity);
    }


    /// <summary>
    /// 带实体与主键的仓储
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    /// <typeparam name="TKey">实体的主键</typeparam>
    public interface IRepository<TEntity, TKey> : IRepository<TEntity> where TEntity : Entity<TKey>, IAggregateRoot 
    {

        bool Delete(TKey id);

        Task<bool> DeleteAsync(TKey id,CancellationToken cancellationToken = default);

        TEntity Get(TKey id);

        Task<TEntity> GetAsync(TKey id,CancellationToken cancellationToken = default);
    }
}
