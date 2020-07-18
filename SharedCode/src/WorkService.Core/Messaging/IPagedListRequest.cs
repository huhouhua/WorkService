using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace WorkService.Core.Messaging
{
    public interface IPagedListRequest : IRequest
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        int Skip { get; }
    }

    public interface IPagedListRequest<out TResponse> :IRequest<TResponse>
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        int Skip { get; }
    }
}
