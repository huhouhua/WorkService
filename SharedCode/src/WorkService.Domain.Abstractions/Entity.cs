using System;
using System.Collections.Generic;
using System.Text;

namespace WorkService.Domain.Abstractions
{
    /// <summary>
    ///  对实体定义一些共享的方法
    /// </summary>
    public abstract class Entity : IEntity
    {

        public abstract object[] GetKeys();



        public override string ToString()
        {
            return $"[Entity:{this.GetType().Name}] Keys = {string.Join(",", this.GetKeys())}";
        }


        #region 领域事件的处理
        private List<IDomainEvent> _domainEvents;


        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();


        public void AddDomainEvent(IDomainEvent eventItem)
        {

            _domainEvents = _domainEvents ?? new List<IDomainEvent>();

            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);

        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
        #endregion
    }

    public abstract class Entity<TKey> : Entity, IEntity<TKey>
    {
        private int? _requestedHashCode;
        public TKey Id { get; protected set; }

        public override object[] GetKeys()
        {
            return new object[] { Id };
        }


        /// <summary>
        /// 表示对象是否相等
        /// 判断二个实体是否是相同的一个实体，
        /// 没有Id 二个实体是不会相等的。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || (obj is Entity<TKey>))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }
            Entity<TKey> item = (Entity<TKey>)obj;
            if (item.IsTransient() || this.IsTransient())
            {
                return false;
            }
            else
            {
                return item.Id.Equals(this.Id);
            }
        }


        /// <summary>
        /// 对比二个对象是否相等
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31;

                return _requestedHashCode.Value;
            }
            else
            {
                return base.GetHashCode();
            }

        }


        /// <summary>
        /// 表示对象是否为全新创建的，未持久化的
        /// </summary>
        /// <returns></returns>
        public bool IsTransient()
        {
            return EqualityComparer<TKey>.Default.Equals(Id, default);

        }

        public override string ToString()
        {
            return $"[Entity:{this.GetType().Name}] Id = {Id}";
        }

        /// <summary>
        /// 用操作符来判断二个对象是否相等  ==
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
        {
            if (Object.Equals(left, null))
            {
                return (Object.Equals(right, null)) ? true : false;
            }
            else
            {
                return left.Equals(right);
            }
        }

        /// <summary>
        /// 用操作符来判断对象是否相等 !=
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Entity<TKey> left, Entity<TKey> right)
        {

            return !(left == right);

        }

    }
}
