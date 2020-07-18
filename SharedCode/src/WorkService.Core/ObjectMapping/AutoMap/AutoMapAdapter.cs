using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace WorkService.Core.ObjectMapping.AutoMap
{
    public class AutoMapAdapter : IObjectMapper
    {
        protected  readonly IMapper _mapper;

        public AutoMapAdapter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public  TDestination MapTo<TDestination>(object source)
        {
            if (source is null) return default(TDestination);

            return _mapper.Map<TDestination>(source);
        }

        public  TDestination MapTo<TSource, TDestination>(TSource source, TDestination destination)
        {
            if (source is null) return default(TDestination);

            return _mapper.Map<TSource, TDestination>(source, destination);
        }

        public  object MapTo(object source, Type sourceType, Type destinationType)
        {
            if (source is null) return source;

            return _mapper.Map(source, sourceType, destinationType);
        }

        public  IEnumerable<TDestination> MapToCollection<TSource, TDestination>(IEnumerable<TSource> source)
        {
            return source.Select<TSource, TDestination>((TSource tSource) =>
            {
                return MapTo<TDestination>(tSource);

            });
        }

        public  IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source)
        {
            if (source is null) return default(IQueryable<TDestination>);

            return _mapper.ProjectTo<TDestination>(source);
        }
    }
}
