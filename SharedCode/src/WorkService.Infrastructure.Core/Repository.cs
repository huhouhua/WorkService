using WorkService.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkService.Infrastructure.Core
{

    /// <summary>
    ///  普通的仓储的实现
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    /// <typeparam name="TDbContext">继承EFContext的上下文</typeparam>
    public abstract class Repository<TEntity, TDbContext> : IRepository<TEntity> where TEntity : Entity, IAggregateRoot where TDbContext : EFContext
    {
        protected virtual TDbContext DbContext { get; set; }

        public virtual IUnitOfWork UnitOfWork => DbContext;

        public Repository(TDbContext context)
        {
            this.DbContext = context;

        }

        public virtual TEntity Add(TEntity entity)
        {
            return DbContext.Add(entity).Entity;
        }

        public virtual Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Add(entity));
        }

        public virtual TEntity Update(TEntity entity)
        {
            return DbContext.Update(entity).Entity;
        }

        public virtual Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Update(entity));
        }

        public virtual bool Remove(Entity entity)
        {
            EntityState state = DbContext.Remove(entity).State;

            if (state.Equals(EntityState.Deleted))
            {
                return true;
            }
            return false;
        }

        public virtual Task<bool> RemoveAsync(Entity entity)
        {
            return Task.FromResult(Remove(entity));
        }


    }


    /// <summary>
    /// 带实体与Id的仓储实现
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    /// <typeparam name="TKey">实体主键</typeparam>
    /// <typeparam name="TDbContext">继承EFContext的上下文</typeparam>

    public abstract class Repository<TEntity, TKey, TDbContext> : Repository<TEntity, TDbContext>, IRepository<TEntity, TKey> where TEntity : Entity<TKey>, IAggregateRoot where TDbContext : EFContext
    {

        public Repository(TDbContext context) : base(context)
        {

        }

        public bool Delete(TKey id)
        {
            var entity = DbContext.Find<TEntity>(id);

            if (entity == null)
            {
                return false;
            }

            EntityState state = DbContext.Remove(entity).State;

            if (state.Equals(EntityState.Deleted))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await DbContext.FindAsync<TEntity>(id, cancellationToken);
            if (entity == null)
            {
                return false;
            }

            EntityState state = DbContext.Remove(entity).State;

            if (state.Equals(EntityState.Deleted))
            {
                return true;
            }
            return false;

        }

        public TEntity Get(TKey id)
        {
            return DbContext.Find<TEntity>(id);
        }

        public async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return await DbContext.FindAsync<TEntity>(id, cancellationToken);
        }
    }
}
