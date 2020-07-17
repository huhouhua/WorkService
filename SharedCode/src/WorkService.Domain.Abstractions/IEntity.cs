using System;
using System.Collections.Generic;
using System.Text;

namespace WorkService.Domain.Abstractions
{
    /// <summary>
    /// 实体的接口
    /// </summary>
    public interface IEntity
    {

        /// <summary>
        /// 表的多个Id
        /// </summary>
        /// <returns></returns>
        object[] GetKeys();

    }

    /// <summary>
    /// 泛型实体
    /// </summary>
    /// <typeparam name="Tkey">表的Id</typeparam>
    public interface IEntity<Tkey> : IEntity
    {

        /// <summary>
        /// 表的Id,表示只有一个Id
        /// </summary>
        Tkey Id { get; }

    }
}
