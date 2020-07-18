using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WorkService.Infrastructure.JobModule.Repositories;

namespace WorkService.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IJobTaskRepository, JobTaskRepository>();

            return services;
        }
    }
}
