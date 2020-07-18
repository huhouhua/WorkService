using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using WorkService.Application.Commands.JobCommands;
using WorkService.Domain.JobModule.JobTaskAggregate;
using WorkService.Infrastructure;

namespace WorkService.API.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddSwagger(this IServiceCollection services,string name, OpenApiInfo info)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name, info);

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);

            });
        }

        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(WorkServiceContextTransactionBehavior<,>));

            return services.AddMediatR(typeof(JobTask).Assembly, typeof(Program).Assembly, typeof(CreateJobTaskCommand).Assembly);
        }

        public static IServiceCollection AddDomainContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        {
            return services.AddDbContext<WorkServiceContext>(optionsAction);
        }

        public static IServiceCollection AddInMemoryDomainContext(this IServiceCollection services)
        {
            return services.AddDomainContext(builder => builder.UseInMemoryDatabase("domanContextDatabase"));
        }

        public static IServiceCollection AddMySqlDomainContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDomainContext(builder =>
            {
                builder.UseMySql(connectionString);
            });
        }

        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<ISubscriberService, SubscriberService>();
            services.AddCap(options =>
            {
                options.UseEntityFramework<WorkServiceContext>();

                options.UseRabbitMQ(options =>
                {
                    configuration.GetSection("RabbitMQ").Bind(options);
                });
                //options.UseDashboard();
            });

            return services;
        }

    }
}
