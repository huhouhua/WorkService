using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace WorkService.Core.ServiceLocation
{
    public static class ServiceLocator
    {
        private static ServiceLocatorProvider currentProvider;

        public static IServiceProvider Current
        {
            get
            {
                return currentProvider();
            }
        }
        public static void SetLocatorProvider(IServiceCollection  services)
        {
            currentProvider = () => { return services.BuildServiceProvider(); };
        }
    }
}
