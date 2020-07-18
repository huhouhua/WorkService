using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WorkService.Core.Messaging
{
    public interface IPagedListResult : IResult
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        int PageCount { get; }
        int TotalItemCount { get; set; }
    }

}
