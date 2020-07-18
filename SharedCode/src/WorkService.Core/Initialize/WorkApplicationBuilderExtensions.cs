using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using WorkService.Core.ServiceLocation;

namespace WorkService.Core.Initialize
{
   public static class WorkApplicationBuilderExtensions
    {
        public static void UseWorkService([NotNull] this IApplicationBuilder app) 
        {
         
        }

    }
}
