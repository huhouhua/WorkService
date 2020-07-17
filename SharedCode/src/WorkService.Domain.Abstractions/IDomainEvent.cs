using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace WorkService.Domain.Abstractions
{
    /// <summary>
    ///领域事件的接口
    /// </summary>
    public interface IDomainEvent : INotification
    {


    }
}
