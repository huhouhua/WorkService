using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using WorkService.Core.Initialize;
using WorkService.Core.ObjectMapping;
using System.Linq;
using WorkService.Core.ObjectMapping.AutoMap;
using WorkService.Core.ServiceLocation;
using System.Threading.Tasks;

namespace WorkService.Core.Test
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            IServiceCollection services = new ServiceCollection();


            services.AddSingleton<dad>();

            services.AddWorkService(options =>
            {
              
            });

            ServiceLocator.SetLocatorProvider(services.BuildServiceProvider());

           var da = ServiceLocator.Current.GetService<dad>();



        }


        public async Task<dad> InitServiceLocator(IServiceCollection services) 
        {
            TestServiceLocator();

            services.AddSingleton<dad>();

            return await Task.FromResult(new dad());
        }

        public async Task<dad> TestServiceLocator()
        {
            Task.Delay(3000);

            var dad = ServiceLocator.Current.GetService<dad>();

            return await Task.FromResult(dad);

        }
    }

   



    public class dad : IObjectMapper
    {
        public TDestination MapTo<TDestination>(object source)
        {
            throw new NotImplementedException();
        }

        public TDestination MapTo<TSource, TDestination>(TSource source, TDestination destination)
        {
            throw new NotImplementedException();
        }

        public object MapTo(object source, Type sourceType, Type destinationType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TDestination> MapToCollection<TSource, TDestination>(IEnumerable<TSource> source)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source)
        {
            throw new NotImplementedException();
        }
    }


}
