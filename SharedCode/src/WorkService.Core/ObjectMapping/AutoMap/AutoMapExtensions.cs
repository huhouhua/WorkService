using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WorkService.Core.ObjectMapping;

namespace WorkService.Core.ObjectMapping.AutoMap
{
    public static class AutoMapExtensions
    {
        public static void AddAutoMapperConfiguration(this IObjectMapper objectMapper, IServiceCollection services, Action<IMapperConfigurationExpression> configure)
        {
            if (configure is null) throw new ArgumentNullException(nameof(configure));
            
            IConfigurationProvider configuration = new MapperConfiguration(configure);

            services.AddSingleton(configuration);
        }

        internal static void AddMapper(this IServiceCollection  services, IObjectMapper  objectMapper)
        {
            if (objectMapper is null)
            {
                objectMapper.AddAutoMapperConfiguration(services,confg=> {});

                services.AddScoped<IMapper, Mapper>();

                var mapperService = services.BuildServiceProvider().GetService<IMapper>();

                ObjectMapperFactory.SetObjectMapper(new AutoMapAdapter(mapperService));

                return;
            }

            ObjectMapperFactory.SetObjectMapper(objectMapper);
        }

    }
}
