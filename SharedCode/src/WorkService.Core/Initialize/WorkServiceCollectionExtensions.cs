using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using WorkService.Core.ObjectMapping.AutoMap;
using WorkService.Core.ServiceLocation;

namespace WorkService.Core.Initialize
{
    public static class WorkServiceCollectionExtensions
    {
        public static IServiceCollection AddWorkService(this IServiceCollection services, [CanBeNull] Action<BootstrapperOptions> optionsAction = null)
        {
            var bootstrapper = Bootstrapper.Create(optionsAction);

            services.AddSingleton(bootstrapper);

            services.AddMapper(bootstrapper.ObjectMapper);

            ServiceLocator.SetLocatorProvider(services);

            return services;
        }
    }
}
